Select * From [User]

Select * From Prop

Select * From Bids

Select * From Inc

Select * From SOLD

SELECT SUM(Ammount) as Ammount from Inc

Insert Into Inc(propId,Ammount) Values();
Update SOLD SET Payment='Paid' where propId='';
Update [User] SET Balance='' where userId=(SELECT userId from SOLD where propId=12);

Delete from Bids where Ammount = 20000

SELECT userId from Bids where Ammount=(SELECT MAX(Ammount) from Bids)

Select TOP 1 [User].userName, Bids.Ammount from [User] 
INNER JOIN Bids ON [User].userId=Bids.userId
where [User].userId=(SELECT userId from Bids where Ammount=(SELECT MAX(Ammount) from Bids)) AND propId=(SELECT propId From Prop Where Title='gfvh') ORDER BY Ammount DESC

UPDATE Prop
SET [status]='Inactive'
where propId=3;

UPDATE Prop
SET Title='Title Test', Dec='Test Dec'
WHERE propId=2;

Delete from Prop where propId=4

Alter Table Bids
Add Constraint FL_casceding
Foreign Key (propId) References Prop(propId) on delete cascade

Select Prop.Title, Prop.Dec,Prop.img, SOLD.Ammount, [User].userName
from ((Prop
Inner Join SOLD on SOLD.propId=Prop.propId)
Inner Join [User] on [User].userId=SOLD.userId)
where Prop.userId=1 and status='Inactive'

SELECT Prop.Title from Prop
INNER Join SOLD on Prop.propId=Sold.PropId
where SOLD.Payment='Unpaid'

SELECT Prop.Dec, Prop.img, Prop.location, [User].userName as Buyer
from((Prop
Inner Join SOLD on SOLD.propId=Prop.PropId)
Inner Join [User] on [User].userId=SOLD.userId)

Select * from (([User]
inner join SOLD on SOLD.userId=[User].userId)
inner join Prop on Prop.propId=SOLD.propId)
where Prop.propId=12

Select userName from [User] where userId=(select userId from Prop where Title='Title Test')

Select Prop.img, Prop.Title, Prop.location, [User].userName, SOLD.Ammount
from ((Prop
Inner Join [User] On Prop.userId=[User].userId)
Inner Join SOLD On Prop.propId=SOLD.propId)
where status='Inactive'

SELECT userName,picture,Balance From [user] where userName='test_seller' And access='Seller'

Select userName, Balance,email,Mobile from [User] where access='Buyer' OR access='Seller'
Select * from Prop Where status='Inactive'