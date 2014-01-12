var model = {
    user: {
        FBId: "",
        VKId: "",
        email: "",
        firstName: "",
        lastName: "",
        thumbnail: "",
        displayOntoUI: function () {
            $("#userName").val(model.user.firstName + " " + model.user.lastName);
            $("#userEmail").val(model.user.email);
            if (model.user.email.trim() !== "")
                $("#userEmail").attr("readonly", "readonly");
        }
    },
    UI: {
        error: "",
        $errorContainer: $(".add-comment-wrap .state"),
        addCommentToList: function () {
            koViewModel.comments.push({
                created: stringifyDateTime(new Date()),
                text: $("#comment").val(),
                user: {
                    firstName: model.user.firstName,
                    lastName: model.user.lastName,
                    thumbnail: model.user.thumbnail
                }
            });
        },
        clearCommentAddingForm: function () {
            model.user.FBId = "";
            model.user.VKId = "";
            model.user.email = "";
            model.user.firstName = "";
            model.user.lastName = "";
            model.user.thumbnail = "";
            $("#comment").val("");
            $("#userName").val("");
            $("#userEmail").val("");
        },
        showSpinner: function () {

        },
        stopSpinner: function () {

        }
    },
    methods: {
        sendComment: function () {
            model.UI.error = "";
            if (model.user.FBId !== "" || model.user.VKId !== "") {
                if ($("#comment").val().trim() !== "") {
                    if ($("#userEmail").val().trim() !== "") //verify for correctness
                    {
                        var objToSend = {
                            Comment: {
                                Text: $("#comment").val(),
                                User: {
                                    FBId: model.user.FBId,
                                    VKId: model.user.VKId,
                                    Email: $("#userEmail").val(),
                                    FirstName: model.user.firstName,
                                    LastName: model.user.lastName,
                                    Thumbnail: model.user.thumbnail
                                }
                            }
                        };
                        $.ajax({
                            url: server.routeUrls.addComment,
                            type: "POST",
                            data: JSON.stringify(objToSend),
                            dataType: "json",
                            contentType: "application/json; charset=utf-8"
                        }).done(function () {
                            model.UI.addCommentToList();
                            model.UI.clearCommentAddingForm();
                        }).fail(function () {
                            model.UI.error = "Произошла ошибка при добавлении комментария";
                            model.UI.$errorContainer.html(model.UI.error);
                        });
                    } else {
                        model.UI.error = "E-mail не должен быть пустым или неправильным";
                    };
                } else {
                    model.UI.error = "Комментарий не должен быть пустым";
                };
            } else {
                model.UI.error = "Авторизуйтесь через Facebook или ВКонтакте";
            };
            if (model.UI.error !== "")
                model.UI.$errorContainer.html(model.UI.error);
        },
        loginToFB: function () {
            model.UI.error = "";
            model.UI.showSpinner();
            FB.init({
                appId: server.configurations.FBAppId
            });
            FB.login(
                function (r1) {
                    if (r1.status === 'connected') {
                        FB.api('/me', function (r2) {
                            console.log("FB:");
                            console.log(r2);
                            model.user.FBId = r2.id.toString();
                            model.user.firstName = r2.first_name;
                            model.user.lastName = r2.last_name;
                            model.user.email = r2.email;
                            model.user.thumbnail = "https://graph.facebook.com/" + model.user.FBId + "/picture?width=100&height=100";
                            model.user.displayOntoUI();
                            model.UI.stopSpinner();
                        });
                    } else {
                        model.UI.error = "Facebook: Неизвестная ошибка";
                        model.UI.stopSpinner();
                    };
                },
                {
                    scope: 'email'
                }
            );
        },
        loginToVK: function () {
            model.UI.error = "";
            model.UI.showSpinner();
            VK.init({
                apiId: server.configurations.VKAppId
            });
            VK.Auth.login(function (r) {
                if (r.session) {
                    console.log("VK:");
                    console.log(r);
                    model.user.VKId = r.session.user.id.toString();
                    model.user.firstName = r.session.user.first_name;
                    model.user.lastName = r.session.user.last_name;
                    var objToSend = {
                        uid: model.user.VKId,
                        fields: "photo_medium"
                    };
                    VK.Api.call("getProfiles", objToSend, function (r1) {
                        model.user.thumbnail = r1.response[0].photo_medium;
                    });
                    model.user.displayOntoUI();
                    model.UI.stopSpinner();
                } else {
                    model.UI.error = "ВКонтакте: Неизвестная ошибка";
                    model.UI.stopSpinner();
                };
            });
        }
    }
};