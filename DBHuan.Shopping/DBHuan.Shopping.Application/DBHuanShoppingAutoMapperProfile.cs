using AutoMapper;
using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHuan.Shopping.Application
{
    /// <summary>
    /// Auto mapper
    /// </summary>
    /// CreatedBy: dbhuan 14/02/2022
    public class DBHuanShoppingAutoMapperProfile: Profile
    {
        public DBHuanShoppingAutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>(MemberList.None);
            CreateMap<Account, AccountDto>(MemberList.None);   

            CreateMap<Admin, AdminDto>(MemberList.None);    
        }
    }
}
