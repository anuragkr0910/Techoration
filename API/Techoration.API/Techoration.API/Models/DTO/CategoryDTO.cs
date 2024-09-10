﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Techoration.API.Models.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        public int SerialNo { get; set; }

        public string Name { get; set; }

        public string URLHandle { get; set; }
    }
}
