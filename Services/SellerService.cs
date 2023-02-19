﻿using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _contex;

        public SellerService(SalesWebMvcContext contex)
        {
            _contex = contex;
        }

        public List<Seller> FinAll()
        {
            return _contex.Seller.ToList();
        }
    }
}