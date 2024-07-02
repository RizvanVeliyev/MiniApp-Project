using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class MedicineService
    {
        public void CreateMedicine(Medicine medicine)
        {
            bool categoryExists = false;
            foreach (var category in DB.categories)
            {
                if (category.Id == medicine.CategoryId)
                {
                    categoryExists = true;
                    break;
                }
            }

            if (!categoryExists)
            {
                throw new NotFoundException("Category not found with the given categoryId.");
            }

            int newLength = DB.medicines.Length + 1;
            Array.Resize(ref DB.medicines, newLength);
            DB.medicines[newLength - 1] = medicine;
        }

        public Medicine[] GetAllmedicines()
        {
            return DB.medicines;
        }

        public Medicine GetMedicineById(int id)
        {
            foreach (var medicine in DB.medicines)
            {
                if (medicine.Id == id)
                {
                    return medicine;
                }
            }
            throw new NotFoundException("Medicine not found with the given id.");
        }

        

        public Medicine[] GetMedicineByCategory(int categoryId)
        {
            int count = 0;
            foreach (var medicine in DB.medicines)
            {
                if (medicine.CategoryId == categoryId)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                throw new NotFoundException("No medicines found for the given categoryId.");
            }

            Medicine[] medicines = new Medicine[count];
            int index = 0;
            foreach (var medicine in DB.medicines)
            {
                if (medicine.CategoryId == categoryId)
                {
                    medicines[index++] = medicine;
                }
            }

            return medicines;
        }

        public void RemoveMedicine(int id)
        {
            int index = -1;
            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new NotFoundException("Medicine not found with the given id.");
            }

            for (int i = index; i < DB.medicines.Length - 1; i++)
            {
                DB.medicines[i] = DB.medicines[i + 1];
            }
            Array.Resize(ref DB.medicines, DB.medicines.Length - 1);
        }

        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            for (int i = 0; i < DB.medicines.Length; i++)
            {
                if (DB.medicines[i].Id == id)
                {
                    DB.medicines[i] = updatedMedicine;
                    return;
                }
            }
            throw new NotFoundException("Medicine not found with the given id.");
        }
    }
}
