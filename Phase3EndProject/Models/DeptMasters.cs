using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Phase3EndProject.Models
{
    [Table("DeptMaster")]
    public class DeptMasters
    {
        [Key]
        public int DeptCode { get; set; }
        public string? DeptName { get; set; }
        public virtual ICollection<EmpProfile>? EmpProfiles { get; set; }
    }

}

