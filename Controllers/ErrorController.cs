using ErrorTranspose.Data;
using ErrorTranspose.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VotreProjet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransposeController : ControllerBase
    {
        private readonly ErrorDbContext _dbContext;

        public TransposeController(ErrorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Transposer les Erreurs")]
        public async Task<IActionResult> ErrorTranspose(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Aucun fichier sélectionné.");

                var errors = new List<Error>();

                using (var stream = file.OpenReadStream())
                {
                    var workbook = new XSSFWorkbook(stream);
                    var sheet = workbook.GetSheetAt(0);

                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        var excelRow = sheet.GetRow(row);
                        if (excelRow == null)
                            continue;

                        var error = new Error
                        {
                            MAJ = excelRow.GetCell(0)?.ToString(),
                            TypeModification = excelRow.GetCell(1)?.ToString(),
                            NatureErreur = excelRow.GetCell(2)?.ToString(),
                            CodeErreur = excelRow.GetCell(3)?.ToString(),
                            Omschrijving = excelRow.GetCell(4)?.ToString(),
                            Libelle = excelRow.GetCell(5)?.ToString(),
                            NatureErreur2 = excelRow.GetCell(6)?.ToString(),
                            CodeErreur2 = excelRow.GetCell(7)?.ToString(),
                            NatureErreur3 = excelRow.GetCell(8)?.ToString(),
                            CodeErreur3 = excelRow.GetCell(9)?.ToString(),
                            NatureErreur4 = excelRow.GetCell(10)?.ToString(),
                            CodeErreur4 = excelRow.GetCell(11)?.ToString(),
                            Remarques = excelRow.GetCell(12)?.ToString()
                        };

                        errors.Add(error);
                    }
                }

                await _dbContext.Errors.AddRangeAsync(errors);
                await _dbContext.SaveChangesAsync();

                return Ok("Données transposées avec succès à partir du fichier Excel.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur lors de la transposition des données à partir du fichier Excel : {ex.Message}");
            }
        }


    }
}
