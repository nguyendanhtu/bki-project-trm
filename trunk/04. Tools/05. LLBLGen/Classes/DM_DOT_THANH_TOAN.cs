///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'DM_DOT_THANH_TOAN'
// Generated by LLBLGen v1.21.2003.712 Final on: Wednesday, November 09, 2011, 10:57:04 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'DM_DOT_THANH_TOAN'.
	/// </summary>
	public class DM_DOT_THANH_TOAN : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_nGAY_TT_DU_KIEN;
			private SqlDecimal		_iD_TRANG_THAI_DOT_TT, _iD_TRANG_THAI_DOT_TTOld, _iD_DON_VI_THANH_TOAN, _iD_DON_VI_THANH_TOANOld, _iD;
			private SqlString		_gHI_CHU, _mA_DOT_TT, _tEN_DOT_TT;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public DM_DOT_THANH_TOAN()
		{
			// Nothing for now.
		}


		/// <summary>
		/// Purpose: Update method. This method will Update one existing row in the database.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID</LI>
		///		 <LI>MA_DOT_TT</LI>
		///		 <LI>TEN_DOT_TT</LI>
		///		 <LI>NGAY_TT_DU_KIEN</LI>
		///		 <LI>ID_TRANG_THAI_DOT_TT</LI>
		///		 <LI>ID_DON_VI_THANH_TOAN</LI>
		///		 <LI>GHI_CHU. May be SqlString.Null</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_DOT_THANH_TOAN_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));
				cmdToExecute.Parameters.Add(new SqlParameter("@sMA_DOT_TT", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _mA_DOT_TT));
				cmdToExecute.Parameters.Add(new SqlParameter("@sTEN_DOT_TT", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _tEN_DOT_TT));
				cmdToExecute.Parameters.Add(new SqlParameter("@daNGAY_TT_DU_KIEN", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nGAY_TT_DU_KIEN));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_DOT_TT", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_DOT_TT));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_DON_VI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DON_VI_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@sGHI_CHU", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _gHI_CHU));

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
				throw new Exception("DM_DOT_THANH_TOAN::Update::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_TRANG_THAI_DOT_TT.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_TRANG_THAI_DOT_TT' in
		/// all rows which have as value for this field the value as set in property 'ID_TRANG_THAI_DOT_TTOld' to 
		/// the value as set in property 'ID_TRANG_THAI_DOT_TT'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_TRANG_THAI_DOT_TT</LI>
		///		 <LI>ID_TRANG_THAI_DOT_TTOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_TRANG_THAI_DOT_TTLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_DOT_THANH_TOAN_UpdateAllWID_TRANG_THAI_DOT_TTLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_DOT_TT", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_DOT_TT));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_DOT_TTOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_DOT_TTOld));

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
				throw new Exception("DM_DOT_THANH_TOAN::UpdateAllWID_TRANG_THAI_DOT_TTLogic::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_DON_VI_THANH_TOAN.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_DON_VI_THANH_TOAN' in
		/// all rows which have as value for this field the value as set in property 'ID_DON_VI_THANH_TOANOld' to 
		/// the value as set in property 'ID_DON_VI_THANH_TOAN'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_DON_VI_THANH_TOAN</LI>
		///		 <LI>ID_DON_VI_THANH_TOANOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_DON_VI_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_DOT_THANH_TOAN_UpdateAllWID_DON_VI_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_DON_VI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DON_VI_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_DON_VI_THANH_TOANOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DON_VI_THANH_TOANOld));

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
				throw new Exception("DM_DOT_THANH_TOAN::UpdateAllWID_DON_VI_THANH_TOANLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_DM_DOT_THANH_TOAN_Delete]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));

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
				throw new Exception("DM_DOT_THANH_TOAN::Delete::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_TRANG_THAI_DOT_TT'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_TRANG_THAI_DOT_TT</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_TRANG_THAI_DOT_TTLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_DOT_THANH_TOAN_DeleteAllWID_TRANG_THAI_DOT_TTLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_DOT_TT", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_DOT_TT));

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
				throw new Exception("DM_DOT_THANH_TOAN::DeleteAllWID_TRANG_THAI_DOT_TTLogic::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_DON_VI_THANH_TOAN'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_DON_VI_THANH_TOAN</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_DON_VI_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_DM_DOT_THANH_TOAN_DeleteAllWID_DON_VI_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_DON_VI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_DON_VI_THANH_TOAN));

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
				throw new Exception("DM_DOT_THANH_TOAN::DeleteAllWID_DON_VI_THANH_TOANLogic::Error occured.", ex);
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


		public SqlString MA_DOT_TT
		{
			get
			{
				return _mA_DOT_TT;
			}
			set
			{
				SqlString mA_DOT_TTTmp = (SqlString)value;
				if(mA_DOT_TTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("MA_DOT_TT", "MA_DOT_TT can't be NULL");
				}
				_mA_DOT_TT = value;
			}
		}


		public SqlString TEN_DOT_TT
		{
			get
			{
				return _tEN_DOT_TT;
			}
			set
			{
				SqlString tEN_DOT_TTTmp = (SqlString)value;
				if(tEN_DOT_TTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TEN_DOT_TT", "TEN_DOT_TT can't be NULL");
				}
				_tEN_DOT_TT = value;
			}
		}


		public SqlDateTime NGAY_TT_DU_KIEN
		{
			get
			{
				return _nGAY_TT_DU_KIEN;
			}
			set
			{
				SqlDateTime nGAY_TT_DU_KIENTmp = (SqlDateTime)value;
				if(nGAY_TT_DU_KIENTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NGAY_TT_DU_KIEN", "NGAY_TT_DU_KIEN can't be NULL");
				}
				_nGAY_TT_DU_KIEN = value;
			}
		}


		public SqlDecimal ID_TRANG_THAI_DOT_TT
		{
			get
			{
				return _iD_TRANG_THAI_DOT_TT;
			}
			set
			{
				SqlDecimal iD_TRANG_THAI_DOT_TTTmp = (SqlDecimal)value;
				if(iD_TRANG_THAI_DOT_TTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_TRANG_THAI_DOT_TT", "ID_TRANG_THAI_DOT_TT can't be NULL");
				}
				_iD_TRANG_THAI_DOT_TT = value;
			}
		}
		public SqlDecimal ID_TRANG_THAI_DOT_TTOld
		{
			get
			{
				return _iD_TRANG_THAI_DOT_TTOld;
			}
			set
			{
				SqlDecimal iD_TRANG_THAI_DOT_TTOldTmp = (SqlDecimal)value;
				if(iD_TRANG_THAI_DOT_TTOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_TRANG_THAI_DOT_TTOld", "ID_TRANG_THAI_DOT_TTOld can't be NULL");
				}
				_iD_TRANG_THAI_DOT_TTOld = value;
			}
		}


		public SqlDecimal ID_DON_VI_THANH_TOAN
		{
			get
			{
				return _iD_DON_VI_THANH_TOAN;
			}
			set
			{
				SqlDecimal iD_DON_VI_THANH_TOANTmp = (SqlDecimal)value;
				if(iD_DON_VI_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_DON_VI_THANH_TOAN", "ID_DON_VI_THANH_TOAN can't be NULL");
				}
				_iD_DON_VI_THANH_TOAN = value;
			}
		}
		public SqlDecimal ID_DON_VI_THANH_TOANOld
		{
			get
			{
				return _iD_DON_VI_THANH_TOANOld;
			}
			set
			{
				SqlDecimal iD_DON_VI_THANH_TOANOldTmp = (SqlDecimal)value;
				if(iD_DON_VI_THANH_TOANOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_DON_VI_THANH_TOANOld", "ID_DON_VI_THANH_TOANOld can't be NULL");
				}
				_iD_DON_VI_THANH_TOANOld = value;
			}
		}


		public SqlString GHI_CHU
		{
			get
			{
				return _gHI_CHU;
			}
			set
			{
				SqlString gHI_CHUTmp = (SqlString)value;
				if(gHI_CHUTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("GHI_CHU", "GHI_CHU can't be NULL");
				}
				_gHI_CHU = value;
			}
		}
		#endregion
	}
}