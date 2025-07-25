﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetByIdAsync(Guid id); // این کد الان متد هستش که میگه با ایدی یه اپارتمان باید پیدا شه و علامت سوال هم برا اینه که بتونه این اپشن خالی باشه یعنی پیدا نشه 
        Task AddAsync(Apartment apartment); // این متدی که من نوشتم برای اینه که بتونه یه اپارتمان جدید اضافه کنه 
        Task<List<Apartment>> GetAllAsync();
    }
}

// متد هارو ای سینک زدیم که بعدا بتونه ای اف کور برگردونه 
// این کد هایی که من نوشتم برای اینترفیس هست که در لایه ی اپلیکیشن نوشته میشه و اینکه اینترفیس یه قرارداد میگه چکاری باید انجام شه انجام نمیده در واقع میگه هرکسی اینو پیاده میکنه باید این متد هارو داشته باشه 