
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [PrimaryKey(nameof(UserId), nameof(ProjectId))]
    public class UserProjectsEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public int ProjectId { get; set; }
        public ProjectEntity Project { get; set; } = null!;
    }
}
