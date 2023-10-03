﻿using AutoPartsShop.Models.DTOs;

namespace AutoPartsShop.WebUI.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetItems();
        Task<ProductDTO> GetItem(int id);
    }
}