using BookingService.Services;
 using BookingService.Models;
namespace BookingService.Data.Repositories
    {
        public class BookingServiceRepository : ICrudRepository<BookingServiceItem, int>
        {
            private readonly BookingContext _bookingContext;
            public BookingServiceRepository(BookingContext bookingContext)
            {
                _bookingContext = bookingContext ?? throw new
                ArgumentNullException(nameof(bookingContext));
            }
            public void Add(BookingServiceItem element)
            {
                _bookingContext.BookingServiceItem.Add(element);
            }
            public void Delete(int id)
            {
                var item = Get(id);
                if (item is not null) _bookingContext.BookingServiceItem.Remove(Get(id));
            }
            public bool Exists(int id)
            {
                return _bookingContext.BookingServiceItem.Any(u => u.Id == id);
            }
          
        public IEnumerable<BookingServiceItem> GetAll()
            {
                return _bookingContext.BookingServiceItem.ToList();
            }
            public bool Save()
            {
                return _bookingContext.SaveChanges() > 0;
            }
            public void Update(BookingServiceItem element)
            {
                _bookingContext.Update(element);
            }

        public BookingServiceItem Get(int id)
        {
            throw new NotImplementedException();
        }
    }
    }


