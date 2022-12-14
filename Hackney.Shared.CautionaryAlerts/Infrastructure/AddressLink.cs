using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackney.Shared.CautionaryAlerts.Infrastructure
{
    [Table("CCAddress", Schema = "dbo")]
    public class AddressLink
    {
        [Key]
        [Column("UPRN")]
        public int AddressNumber { get; set; }

        [Column("PropertyReference")]
        [MaxLength(12)]
        public string PropertyReference { get; set; }

        [Column("RealUPRN")]
        [MaxLength(12)]
        public string UPRN { get; set; }

        [Column("modDate")]
        public DateTime DateModified { get; set; }

        [Column("modUser")]
        [MaxLength(20)]
        [Required]
        public string ModifiedBy { get; set; }

        [Column("modType")]
        [Required]
        public char ModifyType { get; set; }

        [Column("person_name")]
        [MaxLength(100)]
        public string PersonName { get; set; }

        [Column("person_id")]
        [MaxLength(36)]
        public string PersonId { get; set; }

        [Column("assure_reference")]
        [MaxLength(12)]
        public string AssureReference { get; set; }
    }
}
