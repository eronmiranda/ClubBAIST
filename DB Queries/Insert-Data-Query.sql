USE ClubBAISTDB;

-- Memberships Table
INSERT INTO Memberships ([Description])
VALUES ('Gold');

INSERT INTO Memberships ([Description])
VALUES ('Silver');

INSERT INTO Memberships ([Description])
VALUES ('Bronze');

INSERT INTO Memberships ([Description])
VALUES ('Copper');

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