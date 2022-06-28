USE ClubBAISTDB;

-- Memberships Table
INSERT INTO Memberships ([Description]) VALUES
('Gold'),
('Silver'),
('Bronze'),
('Copper');

-- Members Table
INSERT INTO Members ([FirstName]
      ,[LastName]
      ,[Address]
      ,[PostalCode]
      ,[PhoneNumber]
      ,[AltPhoneNumber]
      ,[Email]
      ,[DateOfBirth]
      ,[Occupation]
      ,[CompanyName]
      ,[CompanyAddress]
      ,[CompanyPostalCode]
      ,[CompanyPhoneNumber]
      ,[MembershipID])
VALUES ('',
		'',
		'',
		'',
		null,
		'',
		'',
		'',
		'',
		'',
		'',
		'',
		'');