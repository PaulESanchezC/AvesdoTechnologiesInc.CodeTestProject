﻿using System.ComponentModel.DataAnnotations;

namespace Models.TaxModels;

public class TaxBase
{
    #region Public properties

    [Key]
    public int TaxId { get; set; }

    [Required,Range(0,100)]
    public double TaxPercentage { get; set; }

    [Required,MaxLength(20)]
    public string TaxPercentageString { get; set; }

    [Required, MaxLength(100)]
    public string TaxDescription { get; set; }

    [Required, MaxLength(20)]
    public string TaxAcronym { get; set; }

    #endregion

    #region Internal Properties
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    #endregion
}