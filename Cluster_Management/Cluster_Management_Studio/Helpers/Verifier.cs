using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Helpers.RSA;
using System.Collections.Generic;
using System.Reflection;

namespace Helpers
{
    public class Verifier<T, V> : ControllerBase
    {
        public async Task<IActionResult> Verify(string token, Func<T, V> FunctionCallSuccess, string MessageVerify, T outp)
        {
            try
            {
                // Create object for RSA Verification
                verifyRSA verify = new verifyRSA();
                // Verify the Message
                List<Tuple<string, string>> decrypted = await Task.Run(() => verify.GetMessage(token, MessageVerify));

                // Set the Encrypted Message into the Model
                foreach (var prop in outp.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    // But only if it is writeable the Item
                    // Set Property is allowed
                    if (prop.CanWrite)
                    {
                        Tuple<string, string> value = null;
                        for (int i = 0; i < decrypted.Count; i++)
                            if (decrypted[i].Item1.ToLower() == prop.Name.ToLower())
                            {
                                value = decrypted[i];
                                break;
                            }

                        if (value != null)
                            if (value.Item1 != null && value.Item2 != null)
                                prop.SetValue(outp, value.Item2);
                    }
                }
                return Ok(FunctionCallSuccess(outp));
            }
            catch (Exception x)
            {
                // Logging the Exception x and throw Bad Request
                return BadRequest();
            }
        }
    }
}
