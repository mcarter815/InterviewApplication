using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InterviewApplication.Core.Entities
{
    public class Dashboard : Entity
    {
        [Required]
        public Type Type { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }

    public enum Type
    {
        [Description("Data Import")]
        DataImport = 1,
        [Description("State Report")]
        StateReport = 2,
        [Description("Audit Report")]
        AuditReport = 3
    }

    public enum Status
    {
        Processing = 1,
        Complete = 2,
        Failed = 3
    }
}
