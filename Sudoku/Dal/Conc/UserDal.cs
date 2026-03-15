using Sudoku.Dal.Interfa;
using Sudoku.Data;
using Sudoku.Entity;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sudoku.Dal.Conc
{
    public class UserDal : IUserDal
    {
        public User Create(User user , string password)
        {
            var salt = Guid.NewGuid().ToByteArray();
            
            using (var context = new SudokuDbContext())
            {
                var entity = new UserEntity
                {
                    UserName = user.UserName,
                    Salt = BytesToString(salt),
                    Password =  BytesToString(HashPassword(password,salt))
                };
                context.Users.Add(entity);
                context.SaveChanges();
                user.Id = entity.Id;
                return user;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }

        public byte[] HashPassword (string password , byte[] salt)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var hashAlgorithm = HashAlgorithmName.SHA512;

            var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, 10000,hashAlgorithm);

            return pbkdf2.GetBytes(64);
        }

        public string BytesToString(byte[] bytes)
        {
            var res = new StringBuilder();
            foreach (var item in bytes)
            {
                res.Append(item);
            }
            return res.ToString();
        }
    }
}
