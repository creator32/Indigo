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
        loginViaSocialNetSpinner: new Spinner(spinnerStandartOpts),
        showError: function (error) {
            model.UI.error = error;
            $(".add-comment-wrap .header .state #error-text").html(error);
        },
        clearError: function () {
            model.UI.showError("");
        },
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
            $(".commentlist .comment").last().hide().fadeIn(1500);
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
            var target = $(".add-comment-wrap .header .state #spinner")[0];
            model.UI.loginViaSocialNetSpinner.spin(target);
        },
        stopSpinner: function () {
            model.UI.loginViaSocialNetSpinner.stop();
        }
    },
    methods: {
        sendComment: function () {
            var isValidEmailAddress = function (str) {
                var pattern = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
                return pattern.test(str);
            };
            model.UI.clearError();
            var commentText = $("#comment").val().trim();
            var emailAddress = $("#userEmail").val().trim();
            if ((model.user.FBId !== "") || (model.user.VKId !== "")) {
                if (commentText !== "") {
                    if (emailAddress !== "") {
                        if (isValidEmailAddress(emailAddress)) {
                            var objToSend = {
                                Comment: {
                                    Text: commentText,
                                    User: {
                                        FBId: model.user.FBId,
                                        VKId: model.user.VKId,
                                        Email: emailAddress,
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
                                model.UI.clearError();
                            }).fail(function () {
                                model.UI.showError("Произошла ошибка при добавлении комментария");
                            });
                        } else {
                            model.UI.showError("Адрес электронной почты имеет неверный формат");
                        };
                    } else {
                        model.UI.showError("Введите адрес своей электронной почты");
                    };
                } else {
                    model.UI.showError("Комментарий не должен быть пустым");
                };
            } else {
                model.UI.showError("Авторизуйтесь через Facebook или ВКонтакте");
            };
        },
        loginToFB: function () {
            model.UI.clearError();
            model.UI.showSpinner();
            FB.init({
                appId: server.configurations.FBAppId
            });
            FB.login(
                function (r1) {
                    if (r1.status === 'connected') {
                        FB.api('/me', function (r2) {
                            model.user.FBId = r2.id.toString();
                            model.user.firstName = r2.first_name;
                            model.user.lastName = r2.last_name;
                            model.user.email = r2.email;
                            model.user.thumbnail = "https://graph.facebook.com/" + model.user.FBId + "/picture?width=100&height=100";
                            model.user.displayOntoUI();
                            model.UI.stopSpinner();
                        });
                    } else {
                        model.UI.showError("Facebook: Неизвестная ошибка");
                        model.UI.stopSpinner();
                    };
                },
                {
                    scope: 'email'
                }
            );
        },
        loginToVK: function () {
            model.UI.clearError();
            model.UI.showSpinner();
            VK.init({
                apiId: server.configurations.VKAppId
            });
            VK.Auth.login(function (r) {
                if (r.session) {
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
                    model.UI.showError("ВКонтакте: Неизвестная ошибка");
                    model.UI.stopSpinner();
                };
            });
        }
    }
};