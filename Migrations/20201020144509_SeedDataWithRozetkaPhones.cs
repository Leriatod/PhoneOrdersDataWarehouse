using System.Collections.Generic;
using System.Globalization;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using PhoneDataWarehouse.Data.Models;
using PhoneDataWarehouse.Dtos;
using PhoneDataWarehouse.Mapping;

namespace PhoneDataWarehouse.Migrations
{
    public partial class SeedDataWithRozetkaPhones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string phonesJson = new WebClient().DownloadString("http://my-json-server.typicode.com/Leriatod/PhoneRozetkaService/phones/");
            var phonesRozetka = JsonConvert.DeserializeObject<IEnumerable<RozetkaPhoneDto>>(phonesJson);   

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())));

            var phones = mapper.Map<IEnumerable<RozetkaPhoneDto>, IEnumerable<Phone>>(phonesRozetka);

            foreach (var phone in phones)
            {
                migrationBuilder.Sql(
                    $@"INSERT INTO PHONES (
                        Name, 
                        ScreenSize, 
                        Resolution, 
                        Ram, 
                        InternalStorage, 
                        Capacity, 
                        CategoryName, 
                        OS, 
                        Price, 
                        DescriptionUrl, 
                        ImageUrl
                    ) 
                    VALUES (
                        '{phone.Name}', 
                         {phone.ScreenSize.ToString(CultureInfo.InvariantCulture)}, 
                        '{phone.Resolution}', 
                         {phone.Ram}, 
                         {phone.InternalStorage}, 
                         {phone.Capacity}, 
                        '{phone.CategoryName}', 
                        '{phone.OS}', 
                         {phone.Price.ToString(CultureInfo.InvariantCulture)}, 
                        '{phone.DescriptionUrl}', 
                        '{phone.ImageUrl}'
                    )"
                );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.Sql("DELETE * FROM Phones");
        }
    }
}
