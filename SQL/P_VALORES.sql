/* CFOP | Valor Total da Base de ICMS | Valor Total do ICMS | Valor Total da Base de IPI | Valor Total do IPI
Deve estar agrupado por CFOP.
*/

SET QUOTED_IDENTIFIER ON
GO
SET NOCOUNT ON 
GO 
CREATE PROCEDURE P_VALORES
AS
BEGIN

SELECT CFOP, SUM(BASEICMS) TotalBaseICMS, SUM(VALORICMS) TotalICMS, SUM(BASEIPI) ValorTotalBaseIPI, SUM(VALORIPI) TotalIPI
FROM NOTAFISCALITEM
GROUP BY CFOP
	
END
GO
GRANT EXECUTE ON dbo.P_NOTA_FISCAL_ITEM TO [public]
go
IF OBJECT_ID('dbo.P_NOTA_FISCAL_ITEM') IS NOT NULL
    PRINT '<<< PROCEDURE dbo.P_NOTA_FISCAL_ITEM CRIADA >>>'
ELSE
    PRINT '<<< FALHA NA CRIACAO DA PROCEDURE dbo.P_NOTA_FISCAL_ITEM >>>'
go


