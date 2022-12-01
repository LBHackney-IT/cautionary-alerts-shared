using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackney.Shared.CautionaryAlerts.Infrastructure
{
    [Table("CCContactAlert", Schema = "dbo")]
    public class PersonAlert
    {
        [Column("contactAlertId")]
        [Key]
        public int Id { get; set; }

        [Column("contactNo")]
        [Required]
        public int ContactNumber { get; set; }

        [Column("alertCode")]
        [Required]
        [MaxLength(40)]
        public string AlertCode { get; set; }

        [Column("modDate")]
        [Required]
        public DateTime DateModified { get; set; }

        [Column("modUser")]
        [Required]
        [MaxLength(20)]
        public string ModifiedBy { get; set; }

        [Column("modType")]
        [DefaultValue('I')]
        public char ModifiedType { get; set; }

        [Column("startDate")]
        public DateTime? StartDate { get; set; }

        [Column("endDate")]
        public DateTime? EndDate { get; set; }
    }
}
