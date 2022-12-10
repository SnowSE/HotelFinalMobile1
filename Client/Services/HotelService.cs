﻿using HotelFinal.Client.Pages;
using HotelFinal.Shared;
using System.Collections;
using System.Net.Http.Json;

namespace HotelFinal.Client.Services
{
    public class HotelService
    {
        private readonly HttpClient httpClient;
        private readonly PublicClient publicClient;

        public HotelService(HttpClient httpClient, PublicClient publicClient)
        {
            this.httpClient = httpClient;
            this.publicClient = publicClient;
        }
        
        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            var rooms = await publicClient.Client.GetFromJsonAsync<List<RoomType>>("/api/room/roomtype");
            return rooms;
        }

        public async Task<List<Reservation>> GetAllReservationAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Reservation>>("/api/Reservation/allreservation");
        }
        public async Task<List<ReservationRoom>> GetAllReservationRoomAsync()
        {
            var res = await httpClient.GetFromJsonAsync<List<ReservationRoom>>("/api/room/allreservationroom");
            return res;
        }

        /*public async Task<List<RoomType>> GetAllRoomTypeAsync()
        {
            return await httpClient.GetFromJsonAsync<List<RoomType>>("api/reservation/allroomtype");
        }*/
        public async Task<List<Guest>> GetAllGuestAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Guest>>("/api/reservation/allreservationroom");
        }

        public async Task<List<RoomType>> GetAvailableRoomTypesAsync(DateTime start, DateTime end)
        {
            var s = start.ToString("yyyy-MM-dd");
            var e = end.ToString("yyyy-MM-dd");
            return await httpClient.GetFromJsonAsync<List<RoomType>>($"/api/room/availableRoomTypes/{s}/{e}");
        }

        public async Task<List<Room>> GetAvailableRooms(DateTime start, DateTime end)
        {
            var s = start.ToString("yyyy-MM-dd");
            var e = end.ToString("yyyy-MM-dd");
            return await httpClient.GetFromJsonAsync<List<Room>>($"/api/room/availableRoom/{s}/{e}");
        }

        public async Task<Guest> GetGuestAsync(string firstname, string lastname)
        {
            Guest guest = await httpClient.GetFromJsonAsync<Guest>($"/api/guest/{firstname}/{lastname}");
            return guest;
        }

        public async Task PostGuestAsync(Guest guest)
        {
            await httpClient.PostAsJsonAsync<Guest>("/api/guest", guest);
        }

        public async Task PostReservationsAsync(ReservationPostObject rpo)
        {
            await httpClient.PostAsJsonAsync<ReservationPostObject>("/api/reservation", rpo);
        }

        public async Task<List<RoomCleaningInfo>> GetCleanRoomsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<RoomCleaningInfo>>($"/api/room/cleanrooms");
        }

        public async Task SendReservationConfirmation(ReservationConfirmationObject rco)
        {
            await httpClient.PostAsJsonAsync<ReservationConfirmationObject>("/api/email/reservationConfirmation", rco);
        }

        // Cleaning
        // --------
        public async Task<List<CleaningType>> GetCleaningTypesAsync()
        {
            return await httpClient.GetFromJsonAsync<List<CleaningType>>("/api/cleaning/types");
        }
    }
}
