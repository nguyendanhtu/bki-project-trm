///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'AUCTION'
// Generated by LLBLGen v1.21.2003.712 Final on: 08/09/2011, 2:03:37 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMProLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'AUCTION'.
	/// </summary>
	public class AUCTION : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_rEG_TIME_TO, _rEG_TIME_FROM, _cREATE_DATE, _cLOSE_TIME_TO, _cLOSE_TIME_FROM, _aUCTION_TIME, _rEPAID_TIME_TO, _rEPAID_TIME_FROM, _dELETE_DATE, _mODIFY_DATE;
			private SqlDecimal		_tY_LE_PHI, _aMOUNT_STEP, _rEGISTER_COUNT, _iD_CREATE_BY, _iD_DELETE_BY, _iD_MODIFY_BY, _sTARTING_PRICE, _iD_KIND_OF_STOCK, _iD_KIND_OF_STOCKOld, _tOTAL_OF_STOCK, _fACE_VALUE, _bID_LEVEL, _iD, _pRICE_STEP;
			private SqlString		_tINH_THANH_TO_CHUC, _lA_DAI_LY_YN, _pHAT_TIEN_DAT_COC_YN, _aUCTION_ACCOUNT, _aUCTION_LOCATION, _aUCTION_NAME, _aUCTION_CODE, _cONTACT_ADDRESS, _pAY_LOCATION, _iS_OPEN_YN;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public AUCTION()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Insert method. This method will insert one new row into the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>AUCTION_CODE</LI>
		///		 <LI>AUCTION_NAME</LI>
		///		 <LI>ID_KIND_OF_STOCK. May be SqlDecimal.Null</LI>
		///		 <LI>TOTAL_OF_STOCK</LI>
		///		 <LI>FACE_VALUE</LI>
		///		 <LI>STARTING_PRICE</LI>
		///		 <LI>BID_LEVEL. May be SqlDecimal.Null</LI>
		///		 <LI>PRICE_STEP. May be SqlDecimal.Null</LI>
		///		 <LI>REG_TIME_FROM</LI>
		///		 <LI>REG_TIME_TO</LI>
		///		 <LI>AUCTION_TIME</LI>
		///		 <LI>AUCTION_LOCATION. May be SqlString.Null</LI>
		///		 <LI>CLOSE_TIME_FROM</LI>
		///		 <LI>CLOSE_TIME_TO</LI>
		///		 <LI>IS_OPEN_YN</LI>
		///		 <LI>PAY_LOCATION. May be SqlString.Null</LI>
		///		 <LI>CONTACT_ADDRESS. May be SqlString.Null</LI>
		///		 <LI>REGISTER_COUNT</LI>
		///		 <LI>ID_CREATE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>CREATE_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>ID_MODIFY_BY. May be SqlDecimal.Null</LI>
		///		 <LI>MODIFY_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>ID_DELETE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>DELETE_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>AMOUNT_STEP. May be SqlDecimal.Null</LI>
		///		 <LI>AUCTION_ACCOUNT. May be SqlString.Null</LI>
		///		 <LI>LA_DAI_LY_YN</LI>
		///		 <LI>TY_LE_PHI</LI>
		///		 <LI>PHAT_TIEN_DAT_COC_YN</LI>
		///		 <LI>REPAID_TIME_FROM. May be SqlDateTime.Null</LI>
		///		 <LI>REPAID_TIME_TO. May be SqlDateTime.Null</LI>
		///		 <LI>TINH_THANH_TO_CHUC. May be SqlString.Null</LI>
		/// </UL>
		/// Properties set after a succesful call of this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Insert()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AUCTION_Insert]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_CODE", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_CODE));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_NAME", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_NAME));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_KIND_OF_STOCK", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_KIND_OF_STOCK));
				cmdToExecute.Parameters.Add(new SqlParameter("@TOTAL_OF_STOCK", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tOTAL_OF_STOCK));
				cmdToExecute.Parameters.Add(new SqlParameter("@FACE_VALUE", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _fACE_VALUE));
				cmdToExecute.Parameters.Add(new SqlParameter("@STARTING_PRICE", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sTARTING_PRICE));
				cmdToExecute.Parameters.Add(new SqlParameter("@BID_LEVEL", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 4, 1, "", DataRowVersion.Proposed, _bID_LEVEL));
				cmdToExecute.Parameters.Add(new SqlParameter("@PRICE_STEP", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _pRICE_STEP));
				cmdToExecute.Parameters.Add(new SqlParameter("@REG_TIME_FROM", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEG_TIME_FROM));
				cmdToExecute.Parameters.Add(new SqlParameter("@REG_TIME_TO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEG_TIME_TO));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_TIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_TIME));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_LOCATION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_LOCATION));
				cmdToExecute.Parameters.Add(new SqlParameter("@CLOSE_TIME_FROM", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cLOSE_TIME_FROM));
				cmdToExecute.Parameters.Add(new SqlParameter("@CLOSE_TIME_TO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cLOSE_TIME_TO));
				cmdToExecute.Parameters.Add(new SqlParameter("@IS_OPEN_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _iS_OPEN_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@PAY_LOCATION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _pAY_LOCATION));
				cmdToExecute.Parameters.Add(new SqlParameter("@CONTACT_ADDRESS", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cONTACT_ADDRESS));
				cmdToExecute.Parameters.Add(new SqlParameter("@REGISTER_COUNT", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _rEGISTER_COUNT));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_CREATE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_CREATE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@CREATE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cREATE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_MODIFY_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_MODIFY_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@MODIFY_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mODIFY_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_DELETE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DELETE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@DELETE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dELETE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@AMOUNT_STEP", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _aMOUNT_STEP));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_ACCOUNT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_ACCOUNT));
				cmdToExecute.Parameters.Add(new SqlParameter("@LA_DAI_LY_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lA_DAI_LY_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@TY_LE_PHI", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tY_LE_PHI));
				cmdToExecute.Parameters.Add(new SqlParameter("@PHAT_TIEN_DAT_COC_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _pHAT_TIEN_DAT_COC_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@REPAID_TIME_FROM", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEPAID_TIME_FROM));
				cmdToExecute.Parameters.Add(new SqlParameter("@REPAID_TIME_TO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEPAID_TIME_TO));
				cmdToExecute.Parameters.Add(new SqlParameter("@TINH_THANH_TO_CHUC", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tINH_THANH_TO_CHUC));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Output, false, 18, 1, "", DataRowVersion.Proposed, _iD));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				_iD = (Decimal)cmdToExecute.Parameters["@ID"].Value;
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AUCTION::Insert::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		///		 <LI>AUCTION_CODE</LI>
		///		 <LI>AUCTION_NAME</LI>
		///		 <LI>ID_KIND_OF_STOCK. May be SqlDecimal.Null</LI>
		///		 <LI>TOTAL_OF_STOCK</LI>
		///		 <LI>FACE_VALUE</LI>
		///		 <LI>STARTING_PRICE</LI>
		///		 <LI>BID_LEVEL. May be SqlDecimal.Null</LI>
		///		 <LI>PRICE_STEP. May be SqlDecimal.Null</LI>
		///		 <LI>REG_TIME_FROM</LI>
		///		 <LI>REG_TIME_TO</LI>
		///		 <LI>AUCTION_TIME</LI>
		///		 <LI>AUCTION_LOCATION. May be SqlString.Null</LI>
		///		 <LI>CLOSE_TIME_FROM</LI>
		///		 <LI>CLOSE_TIME_TO</LI>
		///		 <LI>IS_OPEN_YN</LI>
		///		 <LI>PAY_LOCATION. May be SqlString.Null</LI>
		///		 <LI>CONTACT_ADDRESS. May be SqlString.Null</LI>
		///		 <LI>REGISTER_COUNT</LI>
		///		 <LI>ID_CREATE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>CREATE_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>ID_MODIFY_BY. May be SqlDecimal.Null</LI>
		///		 <LI>MODIFY_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>ID_DELETE_BY. May be SqlDecimal.Null</LI>
		///		 <LI>DELETE_DATE. May be SqlDateTime.Null</LI>
		///		 <LI>AMOUNT_STEP. May be SqlDecimal.Null</LI>
		///		 <LI>AUCTION_ACCOUNT. May be SqlString.Null</LI>
		///		 <LI>LA_DAI_LY_YN</LI>
		///		 <LI>TY_LE_PHI</LI>
		///		 <LI>PHAT_TIEN_DAT_COC_YN</LI>
		///		 <LI>REPAID_TIME_FROM. May be SqlDateTime.Null</LI>
		///		 <LI>REPAID_TIME_TO. May be SqlDateTime.Null</LI>
		///		 <LI>TINH_THANH_TO_CHUC. May be SqlString.Null</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AUCTION_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_CODE", SqlDbType.NVarChar, 35, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_CODE));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_NAME", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_NAME));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_KIND_OF_STOCK", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_KIND_OF_STOCK));
				cmdToExecute.Parameters.Add(new SqlParameter("@TOTAL_OF_STOCK", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tOTAL_OF_STOCK));
				cmdToExecute.Parameters.Add(new SqlParameter("@FACE_VALUE", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _fACE_VALUE));
				cmdToExecute.Parameters.Add(new SqlParameter("@STARTING_PRICE", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sTARTING_PRICE));
				cmdToExecute.Parameters.Add(new SqlParameter("@BID_LEVEL", SqlDbType.Decimal, 5, ParameterDirection.Input, false, 4, 1, "", DataRowVersion.Proposed, _bID_LEVEL));
				cmdToExecute.Parameters.Add(new SqlParameter("@PRICE_STEP", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _pRICE_STEP));
				cmdToExecute.Parameters.Add(new SqlParameter("@REG_TIME_FROM", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEG_TIME_FROM));
				cmdToExecute.Parameters.Add(new SqlParameter("@REG_TIME_TO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEG_TIME_TO));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_TIME", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_TIME));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_LOCATION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_LOCATION));
				cmdToExecute.Parameters.Add(new SqlParameter("@CLOSE_TIME_FROM", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cLOSE_TIME_FROM));
				cmdToExecute.Parameters.Add(new SqlParameter("@CLOSE_TIME_TO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cLOSE_TIME_TO));
				cmdToExecute.Parameters.Add(new SqlParameter("@IS_OPEN_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _iS_OPEN_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@PAY_LOCATION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _pAY_LOCATION));
				cmdToExecute.Parameters.Add(new SqlParameter("@CONTACT_ADDRESS", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cONTACT_ADDRESS));
				cmdToExecute.Parameters.Add(new SqlParameter("@REGISTER_COUNT", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _rEGISTER_COUNT));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_CREATE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_CREATE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@CREATE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cREATE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_MODIFY_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_MODIFY_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@MODIFY_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mODIFY_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_DELETE_BY", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DELETE_BY));
				cmdToExecute.Parameters.Add(new SqlParameter("@DELETE_DATE", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dELETE_DATE));
				cmdToExecute.Parameters.Add(new SqlParameter("@AMOUNT_STEP", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _aMOUNT_STEP));
				cmdToExecute.Parameters.Add(new SqlParameter("@AUCTION_ACCOUNT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _aUCTION_ACCOUNT));
				cmdToExecute.Parameters.Add(new SqlParameter("@LA_DAI_LY_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _lA_DAI_LY_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@TY_LE_PHI", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tY_LE_PHI));
				cmdToExecute.Parameters.Add(new SqlParameter("@PHAT_TIEN_DAT_COC_YN", SqlDbType.NVarChar, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _pHAT_TIEN_DAT_COC_YN));
				cmdToExecute.Parameters.Add(new SqlParameter("@REPAID_TIME_FROM", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEPAID_TIME_FROM));
				cmdToExecute.Parameters.Add(new SqlParameter("@REPAID_TIME_TO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEPAID_TIME_TO));
				cmdToExecute.Parameters.Add(new SqlParameter("@TINH_THANH_TO_CHUC", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tINH_THANH_TO_CHUC));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AUCTION::Update::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_KIND_OF_STOCK.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_KIND_OF_STOCK' in
		/// all rows which have as value for this field the value as set in property 'ID_KIND_OF_STOCKOld' to 
		/// the value as set in property 'ID_KIND_OF_STOCK'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_KIND_OF_STOCK. May be SqlDecimal.Null</LI>
		///		 <LI>ID_KIND_OF_STOCKOld. May be SqlDecimal.Null</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_KIND_OF_STOCKLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AUCTION_UpdateAllWID_KIND_OF_STOCKLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_KIND_OF_STOCK", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_KIND_OF_STOCK));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_KIND_OF_STOCKOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_KIND_OF_STOCKOld));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AUCTION::UpdateAllWID_KIND_OF_STOCKLogic::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		/// </UL>
		/// </remarks>
		public override bool Delete()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AUCTION_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AUCTION::Delete::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		/// <summary>
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_KIND_OF_STOCK'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_KIND_OF_STOCK. May be SqlDecimal.Null</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_KIND_OF_STOCKLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_AUCTION_DeleteAllWID_KIND_OF_STOCKLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_KIND_OF_STOCK", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_KIND_OF_STOCK));

				if(_mainConnectionIsCreatedLocal)
				{
					// Open connection.
					_mainConnection.Open();
				}
				else
				{
					if(_mainConnectionProvider.IsTransactionPending)
					{
						cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
					}
				}

				// Execute query.
				_rowsAffected = cmdToExecute.ExecuteNonQuery();
				return true;
			}
			catch(Exception ex)
			{
				// some error occured. Bubble it to caller and encapsulate Exception object
				throw new Exception("AUCTION::DeleteAllWID_KIND_OF_STOCKLogic::Error occured.", ex);
			}
			finally
			{
				if(_mainConnectionIsCreatedLocal)
				{
					// Close connection.
					_mainConnection.Close();
				}
				cmdToExecute.Dispose();
			}
		}


		#region Class Property Declarations
		public SqlDecimal ID
		{
			get
			{
				return _iD;
			}
			set
			{
				SqlDecimal iDTmp = (SqlDecimal)value;
				if(iDTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID", "ID can't be NULL");
				}
				_iD = value;
			}
		}


		public SqlString AUCTION_CODE
		{
			get
			{
				return _aUCTION_CODE;
			}
			set
			{
				SqlString aUCTION_CODETmp = (SqlString)value;
				if(aUCTION_CODETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AUCTION_CODE", "AUCTION_CODE can't be NULL");
				}
				_aUCTION_CODE = value;
			}
		}


		public SqlString AUCTION_NAME
		{
			get
			{
				return _aUCTION_NAME;
			}
			set
			{
				SqlString aUCTION_NAMETmp = (SqlString)value;
				if(aUCTION_NAMETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AUCTION_NAME", "AUCTION_NAME can't be NULL");
				}
				_aUCTION_NAME = value;
			}
		}


		public SqlDecimal ID_KIND_OF_STOCK
		{
			get
			{
				return _iD_KIND_OF_STOCK;
			}
			set
			{
				SqlDecimal iD_KIND_OF_STOCKTmp = (SqlDecimal)value;
				if(iD_KIND_OF_STOCKTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_KIND_OF_STOCK", "ID_KIND_OF_STOCK can't be NULL");
				}
				_iD_KIND_OF_STOCK = value;
			}
		}
		public SqlDecimal ID_KIND_OF_STOCKOld
		{
			get
			{
				return _iD_KIND_OF_STOCKOld;
			}
			set
			{
				SqlDecimal iD_KIND_OF_STOCKOldTmp = (SqlDecimal)value;
				if(iD_KIND_OF_STOCKOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_KIND_OF_STOCKOld", "ID_KIND_OF_STOCKOld can't be NULL");
				}
				_iD_KIND_OF_STOCKOld = value;
			}
		}


		public SqlDecimal TOTAL_OF_STOCK
		{
			get
			{
				return _tOTAL_OF_STOCK;
			}
			set
			{
				SqlDecimal tOTAL_OF_STOCKTmp = (SqlDecimal)value;
				if(tOTAL_OF_STOCKTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TOTAL_OF_STOCK", "TOTAL_OF_STOCK can't be NULL");
				}
				_tOTAL_OF_STOCK = value;
			}
		}


		public SqlDecimal FACE_VALUE
		{
			get
			{
				return _fACE_VALUE;
			}
			set
			{
				SqlDecimal fACE_VALUETmp = (SqlDecimal)value;
				if(fACE_VALUETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("FACE_VALUE", "FACE_VALUE can't be NULL");
				}
				_fACE_VALUE = value;
			}
		}


		public SqlDecimal STARTING_PRICE
		{
			get
			{
				return _sTARTING_PRICE;
			}
			set
			{
				SqlDecimal sTARTING_PRICETmp = (SqlDecimal)value;
				if(sTARTING_PRICETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("STARTING_PRICE", "STARTING_PRICE can't be NULL");
				}
				_sTARTING_PRICE = value;
			}
		}


		public SqlDecimal BID_LEVEL
		{
			get
			{
				return _bID_LEVEL;
			}
			set
			{
				SqlDecimal bID_LEVELTmp = (SqlDecimal)value;
				if(bID_LEVELTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("BID_LEVEL", "BID_LEVEL can't be NULL");
				}
				_bID_LEVEL = value;
			}
		}


		public SqlDecimal PRICE_STEP
		{
			get
			{
				return _pRICE_STEP;
			}
			set
			{
				SqlDecimal pRICE_STEPTmp = (SqlDecimal)value;
				if(pRICE_STEPTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PRICE_STEP", "PRICE_STEP can't be NULL");
				}
				_pRICE_STEP = value;
			}
		}


		public SqlDateTime REG_TIME_FROM
		{
			get
			{
				return _rEG_TIME_FROM;
			}
			set
			{
				SqlDateTime rEG_TIME_FROMTmp = (SqlDateTime)value;
				if(rEG_TIME_FROMTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REG_TIME_FROM", "REG_TIME_FROM can't be NULL");
				}
				_rEG_TIME_FROM = value;
			}
		}


		public SqlDateTime REG_TIME_TO
		{
			get
			{
				return _rEG_TIME_TO;
			}
			set
			{
				SqlDateTime rEG_TIME_TOTmp = (SqlDateTime)value;
				if(rEG_TIME_TOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REG_TIME_TO", "REG_TIME_TO can't be NULL");
				}
				_rEG_TIME_TO = value;
			}
		}


		public SqlDateTime AUCTION_TIME
		{
			get
			{
				return _aUCTION_TIME;
			}
			set
			{
				SqlDateTime aUCTION_TIMETmp = (SqlDateTime)value;
				if(aUCTION_TIMETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AUCTION_TIME", "AUCTION_TIME can't be NULL");
				}
				_aUCTION_TIME = value;
			}
		}


		public SqlString AUCTION_LOCATION
		{
			get
			{
				return _aUCTION_LOCATION;
			}
			set
			{
				SqlString aUCTION_LOCATIONTmp = (SqlString)value;
				if(aUCTION_LOCATIONTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AUCTION_LOCATION", "AUCTION_LOCATION can't be NULL");
				}
				_aUCTION_LOCATION = value;
			}
		}


		public SqlDateTime CLOSE_TIME_FROM
		{
			get
			{
				return _cLOSE_TIME_FROM;
			}
			set
			{
				SqlDateTime cLOSE_TIME_FROMTmp = (SqlDateTime)value;
				if(cLOSE_TIME_FROMTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CLOSE_TIME_FROM", "CLOSE_TIME_FROM can't be NULL");
				}
				_cLOSE_TIME_FROM = value;
			}
		}


		public SqlDateTime CLOSE_TIME_TO
		{
			get
			{
				return _cLOSE_TIME_TO;
			}
			set
			{
				SqlDateTime cLOSE_TIME_TOTmp = (SqlDateTime)value;
				if(cLOSE_TIME_TOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CLOSE_TIME_TO", "CLOSE_TIME_TO can't be NULL");
				}
				_cLOSE_TIME_TO = value;
			}
		}


		public SqlString IS_OPEN_YN
		{
			get
			{
				return _iS_OPEN_YN;
			}
			set
			{
				SqlString iS_OPEN_YNTmp = (SqlString)value;
				if(iS_OPEN_YNTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("IS_OPEN_YN", "IS_OPEN_YN can't be NULL");
				}
				_iS_OPEN_YN = value;
			}
		}


		public SqlString PAY_LOCATION
		{
			get
			{
				return _pAY_LOCATION;
			}
			set
			{
				SqlString pAY_LOCATIONTmp = (SqlString)value;
				if(pAY_LOCATIONTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PAY_LOCATION", "PAY_LOCATION can't be NULL");
				}
				_pAY_LOCATION = value;
			}
		}


		public SqlString CONTACT_ADDRESS
		{
			get
			{
				return _cONTACT_ADDRESS;
			}
			set
			{
				SqlString cONTACT_ADDRESSTmp = (SqlString)value;
				if(cONTACT_ADDRESSTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CONTACT_ADDRESS", "CONTACT_ADDRESS can't be NULL");
				}
				_cONTACT_ADDRESS = value;
			}
		}


		public SqlDecimal REGISTER_COUNT
		{
			get
			{
				return _rEGISTER_COUNT;
			}
			set
			{
				SqlDecimal rEGISTER_COUNTTmp = (SqlDecimal)value;
				if(rEGISTER_COUNTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REGISTER_COUNT", "REGISTER_COUNT can't be NULL");
				}
				_rEGISTER_COUNT = value;
			}
		}


		public SqlDecimal ID_CREATE_BY
		{
			get
			{
				return _iD_CREATE_BY;
			}
			set
			{
				SqlDecimal iD_CREATE_BYTmp = (SqlDecimal)value;
				if(iD_CREATE_BYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_CREATE_BY", "ID_CREATE_BY can't be NULL");
				}
				_iD_CREATE_BY = value;
			}
		}


		public SqlDateTime CREATE_DATE
		{
			get
			{
				return _cREATE_DATE;
			}
			set
			{
				SqlDateTime cREATE_DATETmp = (SqlDateTime)value;
				if(cREATE_DATETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CREATE_DATE", "CREATE_DATE can't be NULL");
				}
				_cREATE_DATE = value;
			}
		}


		public SqlDecimal ID_MODIFY_BY
		{
			get
			{
				return _iD_MODIFY_BY;
			}
			set
			{
				SqlDecimal iD_MODIFY_BYTmp = (SqlDecimal)value;
				if(iD_MODIFY_BYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_MODIFY_BY", "ID_MODIFY_BY can't be NULL");
				}
				_iD_MODIFY_BY = value;
			}
		}


		public SqlDateTime MODIFY_DATE
		{
			get
			{
				return _mODIFY_DATE;
			}
			set
			{
				SqlDateTime mODIFY_DATETmp = (SqlDateTime)value;
				if(mODIFY_DATETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MODIFY_DATE", "MODIFY_DATE can't be NULL");
				}
				_mODIFY_DATE = value;
			}
		}


		public SqlDecimal ID_DELETE_BY
		{
			get
			{
				return _iD_DELETE_BY;
			}
			set
			{
				SqlDecimal iD_DELETE_BYTmp = (SqlDecimal)value;
				if(iD_DELETE_BYTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_DELETE_BY", "ID_DELETE_BY can't be NULL");
				}
				_iD_DELETE_BY = value;
			}
		}


		public SqlDateTime DELETE_DATE
		{
			get
			{
				return _dELETE_DATE;
			}
			set
			{
				SqlDateTime dELETE_DATETmp = (SqlDateTime)value;
				if(dELETE_DATETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DELETE_DATE", "DELETE_DATE can't be NULL");
				}
				_dELETE_DATE = value;
			}
		}


		public SqlDecimal AMOUNT_STEP
		{
			get
			{
				return _aMOUNT_STEP;
			}
			set
			{
				SqlDecimal aMOUNT_STEPTmp = (SqlDecimal)value;
				if(aMOUNT_STEPTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AMOUNT_STEP", "AMOUNT_STEP can't be NULL");
				}
				_aMOUNT_STEP = value;
			}
		}


		public SqlString AUCTION_ACCOUNT
		{
			get
			{
				return _aUCTION_ACCOUNT;
			}
			set
			{
				SqlString aUCTION_ACCOUNTTmp = (SqlString)value;
				if(aUCTION_ACCOUNTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("AUCTION_ACCOUNT", "AUCTION_ACCOUNT can't be NULL");
				}
				_aUCTION_ACCOUNT = value;
			}
		}


		public SqlString LA_DAI_LY_YN
		{
			get
			{
				return _lA_DAI_LY_YN;
			}
			set
			{
				SqlString lA_DAI_LY_YNTmp = (SqlString)value;
				if(lA_DAI_LY_YNTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("LA_DAI_LY_YN", "LA_DAI_LY_YN can't be NULL");
				}
				_lA_DAI_LY_YN = value;
			}
		}


		public SqlDecimal TY_LE_PHI
		{
			get
			{
				return _tY_LE_PHI;
			}
			set
			{
				SqlDecimal tY_LE_PHITmp = (SqlDecimal)value;
				if(tY_LE_PHITmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TY_LE_PHI", "TY_LE_PHI can't be NULL");
				}
				_tY_LE_PHI = value;
			}
		}


		public SqlString PHAT_TIEN_DAT_COC_YN
		{
			get
			{
				return _pHAT_TIEN_DAT_COC_YN;
			}
			set
			{
				SqlString pHAT_TIEN_DAT_COC_YNTmp = (SqlString)value;
				if(pHAT_TIEN_DAT_COC_YNTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("PHAT_TIEN_DAT_COC_YN", "PHAT_TIEN_DAT_COC_YN can't be NULL");
				}
				_pHAT_TIEN_DAT_COC_YN = value;
			}
		}


		public SqlDateTime REPAID_TIME_FROM
		{
			get
			{
				return _rEPAID_TIME_FROM;
			}
			set
			{
				SqlDateTime rEPAID_TIME_FROMTmp = (SqlDateTime)value;
				if(rEPAID_TIME_FROMTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REPAID_TIME_FROM", "REPAID_TIME_FROM can't be NULL");
				}
				_rEPAID_TIME_FROM = value;
			}
		}


		public SqlDateTime REPAID_TIME_TO
		{
			get
			{
				return _rEPAID_TIME_TO;
			}
			set
			{
				SqlDateTime rEPAID_TIME_TOTmp = (SqlDateTime)value;
				if(rEPAID_TIME_TOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REPAID_TIME_TO", "REPAID_TIME_TO can't be NULL");
				}
				_rEPAID_TIME_TO = value;
			}
		}


		public SqlString TINH_THANH_TO_CHUC
		{
			get
			{
				return _tINH_THANH_TO_CHUC;
			}
			set
			{
				SqlString tINH_THANH_TO_CHUCTmp = (SqlString)value;
				if(tINH_THANH_TO_CHUCTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TINH_THANH_TO_CHUC", "TINH_THANH_TO_CHUC can't be NULL");
				}
				_tINH_THANH_TO_CHUC = value;
			}
		}
		#endregion
	}
}