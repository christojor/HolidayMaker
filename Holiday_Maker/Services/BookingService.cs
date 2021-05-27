using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday_Maker.Helper;
using Holiday_Maker.Models;
using Holiday_Maker.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Holiday_Maker.Services
{
    public class BookingService
    {

        private readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IGenericRepository<BookedRoom> _bookedRoomRepository;

        public BookingService()
        {
            _bookingRepository = new GenericRepository<Booking>();
            _bookedRoomRepository = new GenericRepository<BookedRoom>();
        }

        public async Task<bool> CreateBooking(BookingHelper bookingHelper)
        {
            bookingHelper.Booking.BookingDate = DateTime.Now;
            await _bookingRepository.Insert(bookingHelper.Booking);

            foreach (var bookedRoom in bookingHelper.BookedRoom)
            {
                bookedRoom.Id = 0;
                bookedRoom.BookingId = bookingHelper.Booking.Id;
                await _bookedRoomRepository.Insert((bookedRoom));
            }

            //Save for the luls
            //Random randomIdGenerator = new Random();
            //bool bookingIdExistOrNot = true;

            //while (bookingIdExistOrNot)
            //{
            //    var bookingId = randomIdGenerator.Next(1000);
            //    var bookingExist = await _bookingRepository.GetById(bookingId);

            //    if (bookingExist == null)
            //    {
            //        bookingHelper.Booking.Id = bookingId;
            //        await _bookingRepository.Insert(bookingHelper.Booking);

            //        foreach (var roomId in bookingHelper.BookedRoom)
            //        {
            //            await _bookedRoomRepository.Insert(new BookedRoom() {BookingId = bookingId, RoomId = roomId.RoomId});
            //        }
            //        bookingIdExistOrNot = false;
            //    }
            //}

            return true;
        }
    }
}
