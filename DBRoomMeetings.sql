USE [Meetingroom]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sp_CrearReserva]
		@DateOfAdmission = N'2021-05-12 18:00:00.000',
		@DeapertureDate = N'2021-05-12 20:00:00.000',
		@Catering = 1,
		@UserId = '75B37924-60DD-451B-A2F8-21466F7BDE7C',
		@RoomsId = '906E3D3E-355C-47E6-95E1-89330365223D',
		@Status = 1

SELECT	'Return Value' = @return_value

GO
