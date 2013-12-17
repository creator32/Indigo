using System;

namespace TravelerPortal.Data
{
    public interface IHasContentPages
    {
        int Id { get; set; }
        string Name { get; set; }
        string BriefDescriptionPath { get; set; }
        string DetailedDescriptionPath { get; set; }
        DateTime Created { get; set; }
        bool IsActive { get; set; }
    }
}
