CREATE TABLE `Orders` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Reference` VARCHAR(45) NOT NULL,
  `NumberOfAdults` INT(2) NULL DEFAULT 0,
  `NumberOfChildren` INT(2) NULL DEFAULT 0,
  `TotalCost` INT(11) NOT NULL,
  `Country` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `FlightBookings` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Reference` VARCHAR(45) NOT NULL,
  `OrderId` INT,
  `AirlineName` VARCHAR(45) NOT NULL,
  `TotalCost` INT(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `FlightLegs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FlightBookingId` int(11) DEFAULT NULL,
  `Reference` varchar(255) DEFAULT NULL,
  `FromIata` varchar(3) DEFAULT NULL,
  `ToIata` varchar(3) NOT NULL DEFAULT '',
  `DepartureTime` datetime DEFAULT NULL,
  `ArrivalTime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `HotelBookings` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `OrderId` INT,
  `HotelName` VARCHAR(45) NOT NULL,
  `RoomType` VARCHAR(45) NOT NULL,
  `NumberOfBeds` INT(1) NOT NULL,
  `TotalCost` INT(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `HotelBookings` ADD INDEX `Fk_Hotel_Order_idx` (`OrderId` ASC) VISIBLE;

ALTER TABLE `HotelBookings` 
ADD CONSTRAINT `Fk_Hotel_Order`
  FOREIGN KEY (`OrderId`)
  REFERENCES `Orders` (`Id`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;
  
ALTER TABLE `FlightBookings` ADD INDEX `Fk_FlightBooking_Order_idx` (`OrderId` ASC) VISIBLE;

ALTER TABLE `FlightBookings` 
ADD CONSTRAINT `Fk_FlightBooking_Order`
  FOREIGN KEY (`OrderId`)
  REFERENCES `Orders` (`Id`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;
  
ALTER TABLE `FlightLegs` 
ADD INDEX `Fk_FlightLeg_FlightBooking_idx` (`FlightBookingId` ASC) VISIBLE;

ALTER TABLE `FlightLegs` 
ADD CONSTRAINT `Fk_FlightLeg_FlightBooking`
  FOREIGN KEY (`FlightBookingId`)
  REFERENCES `FlightBookings` (`Id`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;
