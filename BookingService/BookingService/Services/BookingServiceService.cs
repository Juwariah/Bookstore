using Microsoft.EntityFrameworkCore;
using BookingService.Controllers;
using BookingService.Data.Repositories;
using BookingService.Models;

namespace BookingService.Services
{
    public class BookingServiceService : ICrudService<BookingServiceItem, int>
    {
            private readonly ICrudRepository<BookingServiceItem, int> _BookingServiceRepository;
            public BookingServiceService(ICrudRepository<BookingServiceItem, int> todoRepository)
            {
                _BookingServiceRepository = todoRepository;
            }
            public void Add(BookingServiceItem element)
            {
                _BookingServiceRepository.Add(element);
                _BookingServiceRepository.Save();
            }
            public void Delete(int id)
            {
                _BookingServiceRepository.Delete(id);
                _BookingServiceRepository.Save();
            }
            public BookingServiceItem Get(int id)
            {
                return _BookingServiceRepository.Get(id);
            }
            public IEnumerable<BookingServiceItem> GetAll()
            {
                return _BookingServiceRepository.GetAll();
            }
            public void Update(BookingServiceItem old, BookingServiceItem newT)
            {
                old.FullName = newT.FullName;
                old.Destination = newT.Destination;
            old.NumberOfPeople = newT.NumberOfPeople;
            old.LengthOfStay = newT.LengthOfStay;

            _BookingServiceRepository.Update(old);
                _BookingServiceRepository.Save();
            }
        }
    }

