using System.Data;

namespace L05HandsOnDB.Models
{
    public class CustomerMapper
    {
        // offset fields
        int _IdOffset = 0;
        int _FirstNameOffset = 1;
        int _LastNameOffset = 2;
        int _CompanyOffset = 3;
        int _AddressOffset = 4;
        int _CityOffset = 5;
        int _StateOffset = 6;
        int _CountryOffset = 7;
        int _PostalCodeOffset = 8;
        int _PhoneOffset = 9;
        int _FaxOffset = 10;
        int _EmailOffset = 11;
        int _SupportRepIdOffset = 12;

        public CustomerMapper(IDataReader reader)
        {
            if (reader.GetOrdinal("CustomerId") != _IdOffset)
            {
                throw new Exception($"The offset of ID is not 0 as expected.  it was {reader.GetOrdinal("CustomerId")}");
            }
            if (reader.GetOrdinal("FirstName") != _FirstNameOffset)
            {
                throw new Exception($"The offset of FirstName is not 1 as expected.  it was {reader.GetOrdinal("FirstName")}");
            }
            if (reader.GetOrdinal("LastName") != _LastNameOffset)
            {
                throw new Exception($"The offset of LastName is not 2 as expected.  it was {reader.GetOrdinal("LastName")}");
            }
            if (reader.GetOrdinal("Company") != _CompanyOffset)
            {
                throw new Exception($"The offset of Company is not 3 as expected.  it was {reader.GetOrdinal("Company")}");
            }
            if (reader.GetOrdinal("Address") != _AddressOffset)
            {
                throw new Exception($"The offset of Address is not 4 as expected.  it was {reader.GetOrdinal("Address")}");
            }
            if (reader.GetOrdinal("City") != _CityOffset)
            {
                throw new Exception($"The offset of City is not 5 as expected.  it was {reader.GetOrdinal("City")}");
            }
            if (reader.GetOrdinal("State") != _StateOffset)
            {
                throw new Exception($"The offset of State is not 6 as expected.  it was {reader.GetOrdinal("State")}");
            }
            if (reader.GetOrdinal("Country") != _CountryOffset)
            {
                throw new Exception($"The offset of Country is not 7 as expected.  it was {reader.GetOrdinal("Country")}");
            }
            if (reader.GetOrdinal("PostalCode") != _PostalCodeOffset)
            {
                throw new Exception($"The offset of PostalCode is not 8 as expected.  it was {reader.GetOrdinal("PostalCode")}");
            }
            if (reader.GetOrdinal("Phone") != _PhoneOffset)
            {
                throw new Exception($"The offset of Phone is not 9 as expected.  it was {reader.GetOrdinal("Phone")}");
            }
            if (reader.GetOrdinal("Fax") != _FaxOffset)
            {
                throw new Exception($"The Fax of Address is not 10 as expected.  it was {reader.GetOrdinal("Fax")}");
            }
            if (reader.GetOrdinal("Email") != _EmailOffset)
            {
                throw new Exception($"The offset of Email is not 11 as expected.  it was {reader.GetOrdinal("Email")}");
            }
            if (reader.GetOrdinal("SupportRepId") != _SupportRepIdOffset)
            {
                throw new Exception($"The offset of SupportRepId is not 12 as expected.  it was {reader.GetOrdinal("SupportRepId")}");
            }
        }
        // ToRating

        public Customer ToCustomer(IDataReader reader)
        {
            Customer customer = new Customer();

            // not nullable in the database, so no null check is required
            customer.Id = reader.GetInt32(_IdOffset);

            // The Id is nullable, so need a null check
            if (reader.IsDBNull(_FirstNameOffset))
            {
                // it is FirstName indeed null
                customer.FirstName = null;
            }
            else
            {
                // the FirstName is NOT null
                customer.FirstName = reader.GetString(_FirstNameOffset);
            }

            // The LastName is nullable, so need a null check
            if (reader.IsDBNull(_LastNameOffset))
            {
                // it is LastName indeed null
                customer.LastName = null;
            }
            else
            {
                // the LastName is NOT null
                customer.LastName = reader.GetString(_LastNameOffset);
            }

            // The Company is nullable, so need a null check
            if (reader.IsDBNull(_CompanyOffset))
            {
                // it is Company indeed null
                customer.Company = null;
            }
            else
            {
                // the Company is NOT null
                customer.Company = reader.GetString(_CompanyOffset);
            }

            // The Address is nullable, so need a null check
            if (reader.IsDBNull(_AddressOffset))
            {
                // it is Address indeed null
                customer.Address = null;
            }
            else
            {
                // the Address is NOT null
                customer.Address = reader.GetString(_AddressOffset);
            }

            // The City is nullable, so need a null check
            if (reader.IsDBNull(_CityOffset))
            {
                // it is City indeed null
                customer.City = null;
            }
            else
            {
                // the City is NOT null
                customer.City = reader.GetString(_CityOffset);
            }

            // The State is nullable, so need a null check
            if (reader.IsDBNull(_StateOffset))
            {
                // it is State indeed null
                customer.State = null;
            }
            else
            {
                // the State is NOT null
                customer.State = reader.GetString(_StateOffset);
            }

            // The Country is nullable, so need a null check
            if (reader.IsDBNull(_CountryOffset))
            {
                // it is Country indeed null
                customer.Country = null;
            }
            else
            {
                // the Country is NOT null
                customer.Country = reader.GetString(_CountryOffset);
            }

            // The PostalCode is nullable, so need a null check
            if (reader.IsDBNull(_PostalCodeOffset))
            {
                // it is PostalCode indeed null
                customer.PostalCode = null;
            }
            else
            {
                // the PostalCode is NOT null
                customer.PostalCode = reader.GetString(_PostalCodeOffset);
            }

            // The Phone is nullable, so need a null check
            if (reader.IsDBNull(_PhoneOffset))
            {
                // it is Phone indeed null
                customer.Phone = null;
            }
            else
            {
                // the Phone is NOT null
                customer.Phone = reader.GetString(_PhoneOffset);
            }

            // The Fax is nullable, so need a null check
            if (reader.IsDBNull(_FaxOffset))
            {
                // it is Fax indeed null
                customer.Fax = null;
            }
            else
            {
                // the Fax is NOT null
                customer.Fax = reader.GetString(_FaxOffset);
            }

            // The Email is nullable, so need a null check
            if (reader.IsDBNull(_EmailOffset))
            {
                // it is Email indeed null
                customer.Email = null;
            }
            else
            {
                // the Email is NOT null
                customer.Email = reader.GetString(_EmailOffset);
            }

            // not nullable in the database, so no null check is required
            customer.SupportRepId = reader.GetInt32(_SupportRepIdOffset);

            return customer;
        }
    }
}
