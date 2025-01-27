///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'GD_THANH_TOAN_DETAIL'
// Generated by LLBLGen v1.21.2003.712 Final on: Thursday, November 17, 2011, 3:39:13 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'GD_THANH_TOAN_DETAIL'.
	/// </summary>
	public class GD_THANH_TOAN_DETAIL : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDecimal		_iD_NOI_DUNG_THANH_TOAN, _iD_NOI_DUNG_THANH_TOANOld, _sO_LUONG_HE_SO, _dON_GIA_TT, _iD_GD_THANH_TOAN, _iD_GD_THANH_TOANOld, _iD;
			private SqlString		_dESCRIPTION, _rEFERENCE_CODE;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public GD_THANH_TOAN_DETAIL()
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
		///		 <LI>ID_GD_THANH_TOAN</LI>
		///		 <LI>DESCRIPTION. May be SqlString.Null</LI>
		///		 <LI>ID_NOI_DUNG_THANH_TOAN</LI>
		///		 <LI>REFERENCE_CODE. May be SqlString.Null</LI>
		///		 <LI>SO_LUONG_HE_SO</LI>
		///		 <LI>DON_GIA_TT</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DETAIL_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_GD_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_GD_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dESCRIPTION));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_NOI_DUNG_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_NOI_DUNG_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@REFERENCE_CODE", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEFERENCE_CODE));
				cmdToExecute.Parameters.Add(new SqlParameter("@SO_LUONG_HE_SO", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sO_LUONG_HE_SO));
				cmdToExecute.Parameters.Add(new SqlParameter("@DON_GIA_TT", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _dON_GIA_TT));

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
				throw new Exception("GD_THANH_TOAN_DETAIL::Update::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_GD_THANH_TOAN.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_GD_THANH_TOAN' in
		/// all rows which have as value for this field the value as set in property 'ID_GD_THANH_TOANOld' to 
		/// the value as set in property 'ID_GD_THANH_TOAN'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_GD_THANH_TOAN</LI>
		///		 <LI>ID_GD_THANH_TOANOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_GD_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DETAIL_UpdateAllWID_GD_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_GD_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_GD_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_GD_THANH_TOANOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_GD_THANH_TOANOld));

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
				throw new Exception("GD_THANH_TOAN_DETAIL::UpdateAllWID_GD_THANH_TOANLogic::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_NOI_DUNG_THANH_TOAN.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_NOI_DUNG_THANH_TOAN' in
		/// all rows which have as value for this field the value as set in property 'ID_NOI_DUNG_THANH_TOANOld' to 
		/// the value as set in property 'ID_NOI_DUNG_THANH_TOAN'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_NOI_DUNG_THANH_TOAN</LI>
		///		 <LI>ID_NOI_DUNG_THANH_TOANOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_NOI_DUNG_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DETAIL_UpdateAllWID_NOI_DUNG_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_NOI_DUNG_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_NOI_DUNG_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_NOI_DUNG_THANH_TOANOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_NOI_DUNG_THANH_TOANOld));

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
				throw new Exception("GD_THANH_TOAN_DETAIL::UpdateAllWID_NOI_DUNG_THANH_TOANLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DETAIL_Delete]";
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
				throw new Exception("GD_THANH_TOAN_DETAIL::Delete::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_GD_THANH_TOAN'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_GD_THANH_TOAN</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_GD_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DETAIL_DeleteAllWID_GD_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_GD_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_GD_THANH_TOAN));

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
				throw new Exception("GD_THANH_TOAN_DETAIL::DeleteAllWID_GD_THANH_TOANLogic::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_NOI_DUNG_THANH_TOAN'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_NOI_DUNG_THANH_TOAN</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_NOI_DUNG_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DETAIL_DeleteAllWID_NOI_DUNG_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@ID_NOI_DUNG_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_NOI_DUNG_THANH_TOAN));

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
				throw new Exception("GD_THANH_TOAN_DETAIL::DeleteAllWID_NOI_DUNG_THANH_TOANLogic::Error occured.", ex);
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


		public SqlDecimal ID_GD_THANH_TOAN
		{
			get
			{
				return _iD_GD_THANH_TOAN;
			}
			set
			{
				SqlDecimal iD_GD_THANH_TOANTmp = (SqlDecimal)value;
				if(iD_GD_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_GD_THANH_TOAN", "ID_GD_THANH_TOAN can't be NULL");
				}
				_iD_GD_THANH_TOAN = value;
			}
		}
		public SqlDecimal ID_GD_THANH_TOANOld
		{
			get
			{
				return _iD_GD_THANH_TOANOld;
			}
			set
			{
				SqlDecimal iD_GD_THANH_TOANOldTmp = (SqlDecimal)value;
				if(iD_GD_THANH_TOANOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_GD_THANH_TOANOld", "ID_GD_THANH_TOANOld can't be NULL");
				}
				_iD_GD_THANH_TOANOld = value;
			}
		}


		public SqlString DESCRIPTION
		{
			get
			{
				return _dESCRIPTION;
			}
			set
			{
				SqlString dESCRIPTIONTmp = (SqlString)value;
				if(dESCRIPTIONTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DESCRIPTION", "DESCRIPTION can't be NULL");
				}
				_dESCRIPTION = value;
			}
		}


		public SqlDecimal ID_NOI_DUNG_THANH_TOAN
		{
			get
			{
				return _iD_NOI_DUNG_THANH_TOAN;
			}
			set
			{
				SqlDecimal iD_NOI_DUNG_THANH_TOANTmp = (SqlDecimal)value;
				if(iD_NOI_DUNG_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_NOI_DUNG_THANH_TOAN", "ID_NOI_DUNG_THANH_TOAN can't be NULL");
				}
				_iD_NOI_DUNG_THANH_TOAN = value;
			}
		}
		public SqlDecimal ID_NOI_DUNG_THANH_TOANOld
		{
			get
			{
				return _iD_NOI_DUNG_THANH_TOANOld;
			}
			set
			{
				SqlDecimal iD_NOI_DUNG_THANH_TOANOldTmp = (SqlDecimal)value;
				if(iD_NOI_DUNG_THANH_TOANOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_NOI_DUNG_THANH_TOANOld", "ID_NOI_DUNG_THANH_TOANOld can't be NULL");
				}
				_iD_NOI_DUNG_THANH_TOANOld = value;
			}
		}


		public SqlString REFERENCE_CODE
		{
			get
			{
				return _rEFERENCE_CODE;
			}
			set
			{
				SqlString rEFERENCE_CODETmp = (SqlString)value;
				if(rEFERENCE_CODETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("REFERENCE_CODE", "REFERENCE_CODE can't be NULL");
				}
				_rEFERENCE_CODE = value;
			}
		}


		public SqlDecimal SO_LUONG_HE_SO
		{
			get
			{
				return _sO_LUONG_HE_SO;
			}
			set
			{
				SqlDecimal sO_LUONG_HE_SOTmp = (SqlDecimal)value;
				if(sO_LUONG_HE_SOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_LUONG_HE_SO", "SO_LUONG_HE_SO can't be NULL");
				}
				_sO_LUONG_HE_SO = value;
			}
		}


		public SqlDecimal DON_GIA_TT
		{
			get
			{
				return _dON_GIA_TT;
			}
			set
			{
				SqlDecimal dON_GIA_TTTmp = (SqlDecimal)value;
				if(dON_GIA_TTTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DON_GIA_TT", "DON_GIA_TT can't be NULL");
				}
				_dON_GIA_TT = value;
			}
		}
		#endregion
	}
}
