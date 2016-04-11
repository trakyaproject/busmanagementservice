using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje.Migrations
{
    [Migration(1)]
    public class _001_vehicleInformation : Migration
    {

        public override void Down()
        {
            Delete.Table("SaveCode");
            Delete.Table("StationRanking");
            Delete.Table("DriverPoint");
            Delete.Table("ShiftTime");
            Delete.Table("BusLocation");
            Delete.Table("Line");
            Delete.Table("BusPersonCount");
            Delete.Table("StationPersonCount");
            Delete.Table("Station");
            Delete.Table("Driver");
            Delete.Table("Bus");
        }

        public override void Up()
        {
            Create.Table("Bus")
                .WithColumn("busId").AsInt32().Identity().PrimaryKey()
                .WithColumn("plate").AsString(128).Unique()
                .WithColumn("busModel").AsString(128)
                .WithColumn("maxBusPessenger").AsInt64()
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime();

            Create.Table("Driver")
                .WithColumn("driverId").AsInt32().Identity().PrimaryKey()
                .WithColumn("nameSurname").AsString(128)
                .WithColumn("picture").AsInt64()
                .WithColumn("tc").AsInt64()
                .WithColumn("birthday").AsDateTime()
                .WithColumn("bloodGroup").AsString(128)
                .WithColumn("phone").AsString(128)
                .WithColumn("address").AsString(256)
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime(); ;

            Create.Table("Station")
                .WithColumn("stationId").AsInt32().Identity().PrimaryKey()
                .WithColumn("stationName").AsString(128)
                .WithColumn("location").AsString(128)
                .WithColumn("address").AsString(128)
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime(); ;

            Create.Table("StationPersonCount")
                .WithColumn("stationPersonCountId").AsInt32().Identity().PrimaryKey()
                .WithColumn("stationPersonCount").AsInt32()
                .WithColumn("stationPersonCountTime").AsDateTime()
                .WithColumn("stationId").AsInt32().ForeignKey("Station", "stationId").OnDelete(Rule.Cascade);

            Create.Table("BusPersonCount")
                .WithColumn("busPersonCountId").AsInt32().Identity().PrimaryKey()
                .WithColumn("busPersonCount").AsInt32()
                .WithColumn("busPersonCountTime").AsDateTime()
                .WithColumn("busId").AsInt32().ForeignKey("Bus", "busId").OnDelete(Rule.Cascade);

            Create.Table("Line")
                .WithColumn("lineId").AsInt32().Identity().PrimaryKey()
                .WithColumn("lineName").AsString(128)
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime(); ;

            Create.Table("BusLocation")
                .WithColumn("busLocationId").AsInt32().Identity().PrimaryKey()
                .WithColumn("busLocation").AsString(128)
                .WithColumn("busLocationTime").AsDateTime()
                .WithColumn("busId").AsInt32().ForeignKey("Bus", "busId").OnDelete(Rule.Cascade)
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime(); ;

            Create.Table("ShiftTime")
                .WithColumn("shiftTimeId").AsInt32().Identity().PrimaryKey()
                .WithColumn("departureTime").AsDateTime()
                .WithColumn("lineId").AsInt32().ForeignKey("Line", "lineId").OnDelete(Rule.Cascade)
                .WithColumn("driverId").AsInt32().ForeignKey("Driver", "driverId").OnDelete(Rule.Cascade)
                .WithColumn("plate").AsInt32().ForeignKey("Bus", "busId").OnDelete(Rule.Cascade)
                .WithColumn("stiftStart").AsDateTime()
                .WithColumn("shiftEnd").AsDateTime()
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime(); ;


            Create.Table("DriverPoint")
                .WithColumn("driverPointId").AsInt32().Identity().PrimaryKey()
                .WithColumn("pointTime").AsDateTime()
                .WithColumn("driverPoint").AsInt32()
                .WithColumn("driverId").AsInt32().ForeignKey("Driver", "driverId").OnDelete(Rule.Cascade)
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime(); ;

            Create.Table("StationRanking")
                .WithColumn("rank").AsInt32()
                .WithColumn("lineId").AsInt32().ForeignKey("Line", "lineId").OnDelete(Rule.Cascade)
                .WithColumn("stationId").AsInt32().ForeignKey("Station", "stationId").OnDelete(Rule.Cascade)
                .WithColumn("state").AsBoolean()
                .WithColumn("createdAt").AsDateTime();

            Create.Table("SaveCode")
                .WithColumn("driverId").AsInt32().ForeignKey("Driver", "driverId").OnDelete(Rule.Cascade)
                .WithColumn("code").AsString(64)
                .WithColumn("dateCode").AsDateTime();
        }
    }
}