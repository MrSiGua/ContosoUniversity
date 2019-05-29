using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        //CourseID 属性上具有 None 参数的 DatabaseGenerated 特性指定主键值由用户提供，而不是由数据库生成。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5)]
        public int Credits { get; set; }

        // Course 实体具有外键属性 DepartmentID，该属性指向相关 Department 实体，同时它还具有 Department 导航属性。
        // 如果拥有相关实体的导航属性，则 Entity Framework 不会要求为数据模型添加外键属性。 
        // 只要有需要，EF 就会自动在数据库中创建外键，并为其创建阴影属性。 但如果数据模型包含外键，则更新会变得更简单、更高效。
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
