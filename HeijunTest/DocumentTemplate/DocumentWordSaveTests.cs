using Xunit;
using HeijunDomain.DocumentTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeijunDomain.DocumentTemplate.Tests
{
    public class DocumentWordSaveTests
    {
        private readonly DocumentWordSave documentWordSave;
        public DocumentWordSaveTests()
        {
            documentWordSave = new DocumentWordSave();
        }

        [Fact()]
        public void DocumentWordSaveMustBeGetTextBoxSpacesTest()
        {
            //arrange
            string path = @"..\..\..\..\src\unionlibreprueba.doc ";
            //act   
            documentWordSave.SaveStructureDocument(path);


        }
        [Fact()]
        public void DocumentWordSaveMustSaveStructureTest()
        {
            //arrange
            string input = @"DECLARACIÓN JURAMENTADA DE UNIÓN LIBRE
                            Fecha %d%  %d%
                            A quien pueda interesar:
                            Yo  %t% nombre de quien diligencia//true %t% con cédula de ciudadanía
                            No. %t% cedula de quien diligencia//true %t% de %l% ciudades// %l%
                            y yo  %t% nombre de pareja//true %t% con cédula de ciudadanía
                            No.  %t% cedula de pareja//true %t% de %l% medellin/bogota/tangamandapio//true %l%
                            Declaramos bajo juramento y en pleno uso de nuestras
                            facultades que vivimos en unión libre y por consentimiento
                            de los dos, desde (fecha aproximada)%d%  %d%
                            Firma
                            c.c.  de
                            Firma
                            c.c. de";
            //act
            List<TextElement> result = documentWordSave.GetTextBoxSpaces(input);
            //Assert
            Assert.Equal(4, result.Count);

        }
        [Fact()]
        public void DocumentWordSaveMustBeGetTextBoxCantSaveDuplicatesSpacesTest()
        {
            //arrange
            string input = @"DECLARACIÓN JURAMENTADA DE UNIÓN LIBRE
                            Fecha %d%  %d%
                            A quien pueda interesar:
                            Yo  %t% nombre de quien diligencia//true %t% con cédula de ciudadanía
                            No. %t% cedula de quien diligencia//true %t% de %l%  Ciudad de expedicion cedula de quien diligencia//medellin%itagui%tangamandapio %l%
                            y yo  %t% nombre de pareja//true %t% con cédula de ciudadanía
                            No.  %t% cedula de la pareja//true %t% de %l% Ciudad de expedicion cedula de la pareja//medellin%itagui%tangamandapio %l%
                            Declaramos bajo juramento y en pleno uso de nuestras
                            facultades que vivimos en unión libre y por consentimiento
                            de los dos, desde (fecha aproximada)%d%  %d%
                            Firma
                            c.c.  %t% cedula de quien diligencia//true %t%   de %l% Ciudad de expedicion cedula de quien diligencia//medellin%itagui%tangamandapio %l%
                            Firma
                            c.c. %t% cedula de la pareja//true %t% de %l% Ciudad de expedicion cedula de la pareja//medellin%itagui%tangamandapio %l%";
            //act
            List<TextElement> result = documentWordSave.GetTextBoxSpaces(input);
            //Assert
            Assert.Equal(4, result.Count);
        }

        [Fact()]
        public void DocumentWordSaveMustBeGetListElementsTest()
        {
            //arrange
            string input = @"DECLARACIÓN JURAMENTADA DE UNIÓN LIBRE
                            Fecha %d%fecha de hoy//true%d%
                            A quien pueda interesar:
                            Yo  %t% nombre de quien diligencia//true %t% con cédula de ciudadanía
                            No. %t% cedula de quien diligencia//true %t% de %l%  Ciudad de expedicion cedula de quien diligencia//medellin%itagui%tangamandapio//true %l%
                            y yo  %t% nombre de pareja//true %t% con cédula de ciudadanía
                            No.  %t% cedula de la pareja//true %t% de %l% Ciudad de expedicion cedula de la pareja//medellin%itagui%tangamandapio//true %l%
                            Declaramos bajo juramento y en pleno uso de nuestras
                            facultades que vivimos en unión libre y por consentimiento
                            de los dos, desde (fecha aproximada)%d%fecha de hoy//true%%d%
                            Firma
                            c.c.  %t% cedula de quien diligencia//true %t%   de %l%  Ciudad de expedicion cedula de quien diligencia//medellin%itagui%tangamandapio//false %l%
                            Firma
                            c.c. %t% cedula de la pareja//true %t% de %l% Ciudad de expedicion cedula de la pareja//medellin%itagui%tangamandapio//false %l% ";
            //act
            List<DateElement> result = documentWordSave.GetDateElements(input);
            //Assert
            Assert.Equal(1, result.Count);

        }

    }
}