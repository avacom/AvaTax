using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AvaTax.Configuration
{
    /// <summary>
    /// Represents the global configuration
    /// </summary>
    public class Configuration
    {
        string name;
        string id;
        string region;
        string city;
        string address;
        string email;
        int zip;
        string code;
        string phone;
        string fax;
        string taxAuthority;
        List<NACE> naces;
        int employeeNumber;
        List<ConfigurationErrors> errors;

        public Configuration()
        {
            name = string.Empty;
            id = string.Empty;
            region = string.Empty;
            city = string.Empty;
            address = string.Empty;
            email = string.Empty;
            zip = 0;
            code = string.Empty;
            phone = string.Empty;
            fax = string.Empty;
            taxAuthority = string.Empty;
            naces = new List<NACE>();
            employeeNumber = 0;
            errors = new List<ConfigurationErrors>();
        }

        /// <summary>
        /// Saves the configuration
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns></returns>
        public bool Save(string fileName)
        {
            bool ret = Validate();
            if (ret)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                    using (TextWriter writer = new StreamWriter(fileName))
                    {
                        serializer.Serialize(writer, this);
                    }
                }
                catch (Exception ex)
                {
                    ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// Load the configuration
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns></returns>
        public bool Load(string fileName)
        {
            bool ret = true;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
                TextReader reader = new StreamReader(fileName);
                object obj = deserializer.Deserialize(reader);
                Configuration loaded = (Configuration)obj;
                LoadFromObject(loaded);
                reader.Close();
            }
            catch(Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        /// <summary>
        /// Copies the values from the provided object
        /// </summary>
        /// <param name="obj">The configuration to be copied</param>
        private void LoadFromObject(Configuration obj)
        {
            if (obj != null)
            {
                name = obj.Name;
                id = obj.ID;
                region = obj.Region;
                city = obj.City;
                address = obj.Address;
                email = obj.Email;
                zip = obj.Zip;
                code = obj.Code;
                phone = obj.Phone;
                fax = obj.Fax;
                taxAuthority = obj.TaxAuthority;
                naces = obj.NACEs;
                employeeNumber = obj.EmployeeNumber;
            }
        }

        /// <summary>
        /// Validate the configuration before save. All the errors are stored in the Errors list
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            bool ret = true;
            errors.Clear();
            return ret;
        }

        /// <summary>
        /// Get or set the name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Get or set the ID
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Get or set the region
        /// </summary>
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        /// <summary>
        /// Get or set the city
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// Get or set the address
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Get or set the email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Get or set the ZIP-code
        /// </summary>
        public int Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        /// <summary>
        /// Get or set the intercity code
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        /// <summary>
        /// Get or set the phone number
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// Get or set the fax number
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        /// <summary>
        /// Get or set the tax authority
        /// </summary>
        public string TaxAuthority
        {
            get { return taxAuthority; }
            set { taxAuthority = value; }
        }

        /// <summary>
        /// Get or set the NACEs
        /// </summary>
        public List<NACE> NACEs
        {
            get { return naces; }
            set { naces = value; }
        }

        /// <summary>
        /// Get or set the number of employees
        /// </summary>
        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        /// <summary>
        /// Get the configuration errors
        /// </summary>
        [XmlIgnore]
        public List<ConfigurationErrors> Errors
        {
            get { return errors; }
        }
    }
}
