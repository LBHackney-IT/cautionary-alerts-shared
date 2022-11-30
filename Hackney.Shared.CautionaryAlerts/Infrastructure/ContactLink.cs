using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackney.Shared.CautionaryAlerts.Infrastructure
{

    [Table("CCContactLink", Schema = "dbo")]
    public class ContactLink
    {
        [Column("ContactNo")]
        public int ContactNumber { get; set; }

        [Column("Key1")]
        [StringLength(20)]
        //Can be a few types of reference including Tag ref and House Ref
        public string Key { get; set; }

        [Column("Key2")]
        [StringLength(10)]
        public string PersonNumber { get; set; }

        [Column("LinkType")]
        [MaxLength(40)]
        public string LinkType { get; set; }

        [Column("LinkNo")]
        [Key]
        public int LinkNumber { get; set; }

        [Column("MODTYPE")]
        [MaxLength(1)]
        public string ModifyType { get; set; }

        [Column("MODDATE")]
        public DateTime? DateModified { get; set; }
    }
}
