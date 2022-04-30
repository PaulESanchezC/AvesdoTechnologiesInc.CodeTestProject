using System.ComponentModel.DataAnnotations;

namespace Models.PreferredPronounsModels;

public class PreferredPronounBase
{
    #region Public Properties

    [Key]
    public int PreferredPronounId { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string Pronouns { get; set; }

    #endregion

    #region Internal Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;

    #endregion
}