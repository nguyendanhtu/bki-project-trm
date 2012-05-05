///////////////////////////////////////////////////////////////////////////
// Description: Data Access class for the table 'GD_THANH_TOAN'
// Generated by LLBLGen v1.21.2003.712 Final on: Wednesday, November 16, 2011, 3:59:43 PM
// Because the Base Class already implements IDispose, this class doesn't.
///////////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace TRMLLBL
{
	/// <summary>
	/// Purpose: Data Access class for the table 'GD_THANH_TOAN'.
	/// </summary>
	public class GD_THANH_TOAN : DBInteractionBase
	{
		#region Class Member Declarations
			private SqlDateTime		_nGAY_THANH_TOAN;
			private SqlDecimal		_tONG_TIEN_THUC_NHAN, _tONG_TIEN_THANH_TOAN, _sO_TIEN_THUE, _iD_TRANG_THAI_THANH_TOAN, _iD_TRANG_THAI_THANH_TOANOld, _iD, _iD_HOP_DONG_KHUNG, _iD_HOP_DONG_KHUNGOld;
			private SqlString		_dESCRIPTION, _rEFERENCE_CODE, _sO_PHIEU_THANH_TOAN, _sO_PHIEU_THANH_TOANOld;
		#endregion


		/// <summary>
		/// Purpose: Class constructor.
		/// </summary>
		public GD_THANH_TOAN()
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
		///		 <LI>SO_PHIEU_THANH_TOAN</LI>
		///		 <LI>ID_HOP_DONG_KHUNG</LI>
		///		 <LI>NGAY_THANH_TOAN</LI>
		///		 <LI>DESCRIPTION. May be SqlString.Null</LI>
		///		 <LI>TONG_TIEN_THANH_TOAN</LI>
		///		 <LI>SO_TIEN_THUE</LI>
		///		 <LI>TONG_TIEN_THUC_NHAN</LI>
		///		 <LI>REFERENCE_CODE. May be SqlString.Null</LI>
		///		 <LI>ID_TRANG_THAI_THANH_TOAN</LI>
		/// </UL>
		/// </remarks>
		public override bool Update()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_Update]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD));
				cmdToExecute.Parameters.Add(new SqlParameter("@sSO_PHIEU_THANH_TOAN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_PHIEU_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_HOP_DONG_KHUNG", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_HOP_DONG_KHUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@daNGAY_THANH_TOAN", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _nGAY_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@sDESCRIPTION", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dESCRIPTION));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcTONG_TIEN_THANH_TOAN", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tONG_TIEN_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcSO_TIEN_THUE", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _sO_TIEN_THUE));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcTONG_TIEN_THUC_NHAN", SqlDbType.Decimal, 13, ParameterDirection.Input, false, 21, 3, "", DataRowVersion.Proposed, _tONG_TIEN_THUC_NHAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@sREFERENCE_CODE", SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _rEFERENCE_CODE));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_THANH_TOAN));

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
				throw new Exception("GD_THANH_TOAN::Update::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'SO_PHIEU_THANH_TOAN.
		/// This method will Update one or more existing rows in the database. It will reset the field 'SO_PHIEU_THANH_TOAN' in
		/// all rows which have as value for this field the value as set in property 'SO_PHIEU_THANH_TOANOld' to 
		/// the value as set in property 'SO_PHIEU_THANH_TOAN'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>SO_PHIEU_THANH_TOAN</LI>
		///		 <LI>SO_PHIEU_THANH_TOANOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWSO_PHIEU_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_UpdateAllWSO_PHIEU_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sSO_PHIEU_THANH_TOAN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_PHIEU_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@sSO_PHIEU_THANH_TOANOld", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_PHIEU_THANH_TOANOld));

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
				throw new Exception("GD_THANH_TOAN::UpdateAllWSO_PHIEU_THANH_TOANLogic::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_HOP_DONG_KHUNG.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_HOP_DONG_KHUNG' in
		/// all rows which have as value for this field the value as set in property 'ID_HOP_DONG_KHUNGOld' to 
		/// the value as set in property 'ID_HOP_DONG_KHUNG'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_HOP_DONG_KHUNG</LI>
		///		 <LI>ID_HOP_DONG_KHUNGOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_HOP_DONG_KHUNGLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_UpdateAllWID_HOP_DONG_KHUNGLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_HOP_DONG_KHUNG", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_HOP_DONG_KHUNG));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_HOP_DONG_KHUNGOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_HOP_DONG_KHUNGOld));

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
				throw new Exception("GD_THANH_TOAN::UpdateAllWID_HOP_DONG_KHUNGLogic::Error occured.", ex);
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
		/// Purpose: Update method for updating one or more rows using the Foreign Key 'ID_TRANG_THAI_THANH_TOAN.
		/// This method will Update one or more existing rows in the database. It will reset the field 'ID_TRANG_THAI_THANH_TOAN' in
		/// all rows which have as value for this field the value as set in property 'ID_TRANG_THAI_THANH_TOANOld' to 
		/// the value as set in property 'ID_TRANG_THAI_THANH_TOAN'.
		/// </summary>
		/// <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_TRANG_THAI_THANH_TOAN</LI>
		///		 <LI>ID_TRANG_THAI_THANH_TOANOld</LI>
		/// </UL>
		/// </remarks>
		public bool UpdateAllWID_TRANG_THAI_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_UpdateAllWID_TRANG_THAI_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_THANH_TOAN));
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_THANH_TOANOld", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_THANH_TOANOld));

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
				throw new Exception("GD_THANH_TOAN::UpdateAllWID_TRANG_THAI_THANH_TOANLogic::Error occured.", ex);
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
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_Delete]";
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
				throw new Exception("GD_THANH_TOAN::Delete::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'SO_PHIEU_THANH_TOAN'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>SO_PHIEU_THANH_TOAN</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWSO_PHIEU_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DeleteAllWSO_PHIEU_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@sSO_PHIEU_THANH_TOAN", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _sO_PHIEU_THANH_TOAN));

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
				throw new Exception("GD_THANH_TOAN::DeleteAllWSO_PHIEU_THANH_TOANLogic::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_HOP_DONG_KHUNG'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_HOP_DONG_KHUNG</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_HOP_DONG_KHUNGLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DeleteAllWID_HOP_DONG_KHUNGLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_HOP_DONG_KHUNG", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_HOP_DONG_KHUNG));

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
				throw new Exception("GD_THANH_TOAN::DeleteAllWID_HOP_DONG_KHUNGLogic::Error occured.", ex);
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
		/// Purpose: Delete method for a foreign key. This method will Delete one or more rows from the database, based on the Foreign Key 'ID_TRANG_THAI_THANH_TOAN'
		/// </summary>
		/// <returns>True if succeeded, false otherwise. </returns>
		/// <remarks>
		/// Properties needed for this method: 
		/// <UL>
		///		 <LI>ID_TRANG_THAI_THANH_TOAN</LI>
		/// </UL>
		/// </remarks>
		public bool DeleteAllWID_TRANG_THAI_THANH_TOANLogic()
		{
			SqlCommand	cmdToExecute = new SqlCommand();
			cmdToExecute.CommandText = "dbo.[pr_GD_THANH_TOAN_DeleteAllWID_TRANG_THAI_THANH_TOANLogic]";
			cmdToExecute.CommandType = CommandType.StoredProcedure;

			// Use base class' connection object
			cmdToExecute.Connection = _mainConnection;

			try
			{
				cmdToExecute.Parameters.Add(new SqlParameter("@dcID_TRANG_THAI_THANH_TOAN", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, _iD_TRANG_THAI_THANH_TOAN));

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
				throw new Exception("GD_THANH_TOAN::DeleteAllWID_TRANG_THAI_THANH_TOANLogic::Error occured.", ex);
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


		public SqlString SO_PHIEU_THANH_TOAN
		{
			get
			{
				return _sO_PHIEU_THANH_TOAN;
			}
			set
			{
				SqlString sO_PHIEU_THANH_TOANTmp = (SqlString)value;
				if(sO_PHIEU_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_PHIEU_THANH_TOAN", "SO_PHIEU_THANH_TOAN can't be NULL");
				}
				_sO_PHIEU_THANH_TOAN = value;
			}
		}
		public SqlString SO_PHIEU_THANH_TOANOld
		{
			get
			{
				return _sO_PHIEU_THANH_TOANOld;
			}
			set
			{
				SqlString sO_PHIEU_THANH_TOANOldTmp = (SqlString)value;
				if(sO_PHIEU_THANH_TOANOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_PHIEU_THANH_TOANOld", "SO_PHIEU_THANH_TOANOld can't be NULL");
				}
				_sO_PHIEU_THANH_TOANOld = value;
			}
		}


		public SqlDecimal ID_HOP_DONG_KHUNG
		{
			get
			{
				return _iD_HOP_DONG_KHUNG;
			}
			set
			{
				SqlDecimal iD_HOP_DONG_KHUNGTmp = (SqlDecimal)value;
				if(iD_HOP_DONG_KHUNGTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_HOP_DONG_KHUNG", "ID_HOP_DONG_KHUNG can't be NULL");
				}
				_iD_HOP_DONG_KHUNG = value;
			}
		}
		public SqlDecimal ID_HOP_DONG_KHUNGOld
		{
			get
			{
				return _iD_HOP_DONG_KHUNGOld;
			}
			set
			{
				SqlDecimal iD_HOP_DONG_KHUNGOldTmp = (SqlDecimal)value;
				if(iD_HOP_DONG_KHUNGOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_HOP_DONG_KHUNGOld", "ID_HOP_DONG_KHUNGOld can't be NULL");
				}
				_iD_HOP_DONG_KHUNGOld = value;
			}
		}


		public SqlDateTime NGAY_THANH_TOAN
		{
			get
			{
				return _nGAY_THANH_TOAN;
			}
			set
			{
				SqlDateTime nGAY_THANH_TOANTmp = (SqlDateTime)value;
				if(nGAY_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("NGAY_THANH_TOAN", "NGAY_THANH_TOAN can't be NULL");
				}
				_nGAY_THANH_TOAN = value;
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


		public SqlDecimal TONG_TIEN_THANH_TOAN
		{
			get
			{
				return _tONG_TIEN_THANH_TOAN;
			}
			set
			{
				SqlDecimal tONG_TIEN_THANH_TOANTmp = (SqlDecimal)value;
				if(tONG_TIEN_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TONG_TIEN_THANH_TOAN", "TONG_TIEN_THANH_TOAN can't be NULL");
				}
				_tONG_TIEN_THANH_TOAN = value;
			}
		}


		public SqlDecimal SO_TIEN_THUE
		{
			get
			{
				return _sO_TIEN_THUE;
			}
			set
			{
				SqlDecimal sO_TIEN_THUETmp = (SqlDecimal)value;
				if(sO_TIEN_THUETmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("SO_TIEN_THUE", "SO_TIEN_THUE can't be NULL");
				}
				_sO_TIEN_THUE = value;
			}
		}


		public SqlDecimal TONG_TIEN_THUC_NHAN
		{
			get
			{
				return _tONG_TIEN_THUC_NHAN;
			}
			set
			{
				SqlDecimal tONG_TIEN_THUC_NHANTmp = (SqlDecimal)value;
				if(tONG_TIEN_THUC_NHANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("TONG_TIEN_THUC_NHAN", "TONG_TIEN_THUC_NHAN can't be NULL");
				}
				_tONG_TIEN_THUC_NHAN = value;
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


		public SqlDecimal ID_TRANG_THAI_THANH_TOAN
		{
			get
			{
				return _iD_TRANG_THAI_THANH_TOAN;
			}
			set
			{
				SqlDecimal iD_TRANG_THAI_THANH_TOANTmp = (SqlDecimal)value;
				if(iD_TRANG_THAI_THANH_TOANTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_TRANG_THAI_THANH_TOAN", "ID_TRANG_THAI_THANH_TOAN can't be NULL");
				}
				_iD_TRANG_THAI_THANH_TOAN = value;
			}
		}
		public SqlDecimal ID_TRANG_THAI_THANH_TOANOld
		{
			get
			{
				return _iD_TRANG_THAI_THANH_TOANOld;
			}
			set
			{
				SqlDecimal iD_TRANG_THAI_THANH_TOANOldTmp = (SqlDecimal)value;
				if(iD_TRANG_THAI_THANH_TOANOldTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_TRANG_THAI_THANH_TOANOld", "ID_TRANG_THAI_THANH_TOANOld can't be NULL");
				}
				_iD_TRANG_THAI_THANH_TOANOld = value;
			}
		}
		#endregion
	}
}