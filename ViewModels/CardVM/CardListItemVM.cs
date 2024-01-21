﻿using System.ComponentModel.DataAnnotations;

namespace ExamMVC.ViewModels.CardVM
{
    public class CardListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}
