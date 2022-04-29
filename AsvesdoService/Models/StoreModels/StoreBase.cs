﻿using System.ComponentModel.DataAnnotations;
using Models.PreferredPronounsModels;

namespace Models.StoreModels;

public class StoreBase
{
    #region Public Properties

    [Key]
    public string StoreId { get; set; } = Guid.NewGuid().ToString();

    [Required(AllowEmptyStrings = false), MaxLength(200)]
    public string StoreName { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(50)]
    public string StorePhoneNumber { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100), EmailAddress]
    public string StoreEmail { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100), Url]
    public string StoreWebsite { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(300)]
    public string StoreAddress { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string StoreCity { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(100)]
    public string StoreStateOrProvince { get; set; }

    [Required(AllowEmptyStrings = false), MaxLength(20)]
    public string StoreZipCode { get; set; }

    #endregion

    #region Internal Properties

    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public List<Staff> StaffList { get; set; }

    #endregion
}