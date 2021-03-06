USE [Shipping_12_12_2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetJobTruckConsignmentNoteReport]    Script Date: 12/15/2016 16:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_GetJobTruckConsignmentNoteReport]
(
@JobID int
)
AS
BEGIN
SELECT JCargoDescription.Mark,JCargoDescription.Packages,JCargoDescription.volume, JCargoDescription.weight, Consignee.Customer as ConsigneeCust, Consignee.Phone as ConsigneePhn, Notify.Customer as NotifyCust,
 Notify.Address1 as NotifyAddrs, Notify.Phone as NotifyPhn, Port.Port as Port, DestinationPort.Port As DestiPort, JobGeneration.JobDate, JobGeneration.DeliveryOrderDate,
 JCargoDescription.CargoDescriptionID, JobGeneration.TruckRegNo, JobGeneration.DriverDetails, JobGeneration.TDN, JobGeneration.CLFValue,
 JobGeneration.DeliveryInstructions, Consignee.Address1 as ConsigneeAddrs1, Consignee.Address2 as ConsigneeAddrs2, Consignee.Address3 as ConsigneeAddrs3, Notify.Address2 as NotifyAddrs2, Notify.Address3 as NotifyAddrs3,
 CUSTOMER.Customer as CUSTOMERCust, CUSTOMER.Address1 as CUSTOMERAddrs1, CUSTOMER.Address2 as CUSTOMERAddrs2, CUSTOMER.Address3 as CUSTOMERAddrs3, CUSTOMER.Phone as CUSTOMERPhn, JobGeneration.JobCode, JobGeneration.JobID, JCargoDescription.Description
 FROM   (((((JobGeneration JobGeneration LEFT OUTER JOIN JCargoDescription JCargoDescription ON JobGeneration.JobID=JCargoDescription.JobID) 
 LEFT OUTER JOIN CUSTOMER CUSTOMER ON JobGeneration.ConsignerID=CUSTOMER.CustomerID)
 LEFT OUTER JOIN CUSTOMER Consignee ON JobGeneration.ConsigneeID=Consignee.CustomerID)
 LEFT OUTER JOIN CUSTOMER Notify ON JobGeneration.ShipperID=Notify.CustomerID)
 LEFT OUTER JOIN Port Port ON JobGeneration.LoadPortID=Port.PortID)
 LEFT OUTER JOIN Port DestinationPort ON JobGeneration.DestinationPortID=DestinationPort.PortID
 Where JobGeneration.JobID=@JobID
 ORDER BY JCargoDescription.CargoDescriptionID
END
GO
/****** Object:  StoredProcedure [dbo].[ProSupplierLedger]    Script Date: 12/15/2016 16:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProSupplierLedger]
@intSupplierID as int=0,
@DteFromDate as varchar(20),
@DteToDate as varchar(20)
AS 


SET NOCOUNT ON
set FMTONLY OFF
DECLARE @charVoucherNo varchar(20),
	@dteInvoiceDate datetime, 
	@mnyDebit Money, 
	@mnycredit Money, 
	@charParticulars varchar(50),
	@intPartyID int,
	@strStatusentry varchar(20),@intSupplierControlHeadID int
	
	set FMTONLY OFF
select @intSupplierControlHeadID = SupplierControlAcID from AcHeadAssign  
set FMTONLY OFF
Create table #TempLedger(VoucherNo varchar(20), InvoiceDate datetime, 
	Debit Money, credit Money, Particulars varchar(50), SupplierID int,Statusentry varchar(20))
set FMTONLY OFF
Create table #Ledger(VoucherNo varchar(20), InvoiceDate datetime, 
	Debit Money, credit Money, Particulars varchar(50), SupplierID int,Statusentry varchar(20))
set FMTONLY OFF
-- +++++++++++++++++++++++++++++++++++++++
	INSERT INTO #TempLedger(VoucherNo, InvoiceDate, Debit, credit, 
	Particulars, SupplierID,Statusentry) 

	SELECT InvoiceNo AS VoucherNo,InvoiceDate,0 AS Debit,
	ISNULL ((SELECT     SUM(Cost) AS Expr1 FROM CostUpdationDetails
	WHERE  (CostUpdationID = dbo.CostUpdation.CostUpdationID)), 0) as Credit,'Invoice' AS Particulars, 
	Supplier.SupplierID,'I' AS Statusentry FROM CostUpdation INNER JOIN Supplier ON 
	CostUpdation.SupplierID = Supplier.SupplierID

	UNION ALL 
	
	SELECT   RecPay.DocumentNo AS VoucherNo,  RecPay.RecPayDate AS InvoiceDate, 
	(SELECT    SUM(isnull(Amount,0))FROM RecPayDetails WHERE RecPayDetails.RecPayID = 
	RecPay.RecPayID AND amount > 0 ) AS Debit,0 AS Credit ,
	'Recipt Vouchar No' AS Particulars, Supplier.SupplierID,Statusentry
	FROM RecPay INNER JOIN Supplier ON RecPay.SupplierID = Supplier.SupplierID inner join 
	acmemojournalmaster on acmemojournalmaster.acmemojournalID = RecPay.AcjournalID
	where   statusentry='PD' and acmemojournalmaster.AcjournalID >0	 

	union all 
	
	SELECT   RecPay.DocumentNo AS VoucherNo, RecPay.RecPayDate AS InvoiceDate, 
	(SELECT   SUM(isnull(Amount,0))FROM RecPayDetails WHERE RecPayDetails.RecPayID 
	= RecPay.RecPayID AND amount < 0)*-1 AS Debit,0 AS Credit ,
	'Recipt Vouchar No' AS Particulars, Supplier.SupplierID,Statusentry
	FROM RecPay INNER JOIN Supplier ON RecPay.SupplierID = Supplier.SupplierID  
	where recpay.DocumentNo not like 'RA%' and   statusentry<>'PD' 
union all 
SELECT 
AcOPInvoiceDetails.InvoiceNo AS DocumentNo,  AcOPInvoiceDetails.InvoiceDate AS TransDate, 
ISNULL((AcOPInvoiceDetails.Amount),0)  AS Rec, 
0 AS Pay, 'Opening'  AS Particulars, AcOPInvoiceMaster.PartyID as SupplierID   ,'O' Statusentry
FROM  AcOPInvoiceDetails INNER JOIN AcOPInvoiceMaster ON
 AcOPInvoiceDetails.AcOPInvoiceMasterID = AcOPInvoiceMaster.AcOPInvoiceMasterID
WHERE     (AcOPInvoiceMaster.StatusSDSC = 'SC') AND
 (AcOPInvoiceDetails.Amount > 0)


UNION all SELECT 
AcOPInvoiceDetails.InvoiceNo AS DocumentNo,  AcOPInvoiceDetails.InvoiceDate AS TransDate, 
 0 AS Rec, ISNULL((AcOPInvoiceDetails.Amount),0)  AS Pay, 
 'Opening'  AS Particulars, AcOPInvoiceMaster.PartyID as SupplierID   ,'O' Statusentry
FROM  AcOPInvoiceDetails INNER JOIN AcOPInvoiceMaster ON
 AcOPInvoiceDetails.AcOPInvoiceMasterID = AcOPInvoiceMaster.AcOPInvoiceMasterID
WHERE     (AcOPInvoiceMaster.StatusSDSC = 'SC') AND
 (AcOPInvoiceDetails.Amount < 0)
 
 
 
UNION all SELECT    AcJournalMaster.VoucherNo, 
AcJournalMaster.TransDate, 
(case WHEN Isnull(AcJournalDetail.Amount,0)< 0 THEN Isnull(abs(AcJournalDetail.Amount),0) ELSE 0
END) as Rec, (case WHEN Isnull(AcJournalDetail.Amount,0)>0 THEN Isnull(abs(AcJournalDetail.Amount),0)  ELSE 0
END) as Pay, 'JV'  AS Particulars, CustSuppJV.SupplierID as SupplierID   ,'J' Statusentry  FROM (CustSuppJV INNER JOIN AcJournalMaster ON CustSuppJV.AcJournalID = 
AcJournalMaster.AcJournalID) INNER JOIN AcJournalDetail ON AcJournalMaster.AcJournalID 
= AcJournalDetail.AcJournalID Where CustSuppJV.CustomerID Is Null And 
AcJournalDetail.AcHeadID  <>@intSupplierControlHeadID

	 
	 
---- ++++++++++++++++++++++++++  Opening +++++++++++++++++
set FMTONLY OFF
DECLARE CurLedgers cursor for

	SELECT  SupplierID, SUM(Debit) AS Debit, SUM(credit) AS credit,Statusentry
	FROM     #TempLedger where InvoiceDate  < @DteFromDate
	GROUP BY SupplierID,Statusentry

Open CurLedgers
fetch CurLedgers into @intPartyID ,  @mnyDebit, @mnycredit,@strStatusentry
	 
While @@fetch_status = 0 
BEGIN
set FMTONLY OFF
	INSERT INTO #Ledger(VoucherNo, InvoiceDate, Debit, credit, 
	Particulars, SupplierID,Statusentry) VALUES ('Opening Balance', @DteFromDate, 
	@mnyDebit, @mnycredit, 'Opening Balance', @intPartyID,@strStatusentry)

fetch CurLedgers into @intPartyID ,  @mnyDebit, @mnycredit,@strStatusentry

END

Close CurLedgers
Deallocate CurLedgers


-- #################################
set FMTONLY OFF
DECLARE CurLedgers cursor for

select * from #TempLedger where InvoiceDate  >= @DteFromDate and InvoiceDate  <= @DteToDate

Open CurLedgers
fetch CurLedgers into @charVoucherNo, @dteInvoiceDate, @mnyDebit, @mnycredit,
	@charParticulars, @intPartyID ,@strStatusentry
While @@fetch_status = 0 
BEGIN
set FMTONLY OFF
	INSERT INTO #Ledger(VoucherNo, InvoiceDate, Debit, credit, 
	Particulars, SupplierID,Statusentry) VALUES (@charVoucherNo, @dteInvoiceDate, 
	@mnyDebit, @mnycredit, @charParticulars, @intPartyID,@strStatusentry)

fetch CurLedgers into @charVoucherNo, @dteInvoiceDate, @mnyDebit, @mnycredit,
	@charParticulars, @intPartyID ,@strStatusentry
END

Close CurLedgers
Deallocate CurLedgers



begin 
set FMTONLY OFF
	if @intSupplierID<> 0 
		SELECT  #Ledger.SupplierID,VoucherNo, InvoiceDate as Date, Debit, credit, 
		Particulars, SupplierNAme, ReferenceCode, Phone,
		Address1, Address2, Address3,Statusentry  FROM #Ledger INNER JOIN 
		Supplier ON Supplier.SupplierID = 
		#Ledger.SupplierID 
		where #Ledger.SupplierID=@intSupplierID
		ORDER BY SupplierID,VoucherNo,InvoiceDate

	else
		SELECT  #Ledger.SupplierID,VoucherNo, InvoiceDate as Date, Debit, credit, 
		Particulars, SupplierNAme, ReferenceCode, Phone,
		Address1, Address2, Address3,Statusentry  FROM #Ledger INNER JOIN 
		Supplier ON Supplier.SupplierID = 
		#Ledger.SupplierID 
		ORDER BY SupplierID,VoucherNo,InvoiceDate

end
GO
