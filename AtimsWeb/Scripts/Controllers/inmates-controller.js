/// Inmates UI-Grid Controller
atimsApp.controller('InmatesController',  function ($scope,$http,InmatesService) {
    // Grid Options
    // @TOOD: Add column information to match the simple ViewModel for Inmates
    //   so that columns can be appropriately sized and linked to data
    $scope.gridOptions = {enableFiltering: true, exportCsvFilename:'Inmates.csv', enableGridMenu: true,
        enableSelectAll: true, exporterCsvFilename: 'myFile.csv',
        exporterPdfDefaultStyle: { fontSize: 9 },
        exporterPdfTableStyle: { margin: [30, 30, 30, 30] },
        exporterPdfTableHeaderStyle: { fontSize: 10, bold: true, italics: true, color: 'red' },
        exporterPdfHeader: { text: "My Header", style: 'headerStyle' },
        exporterPdfFooter: function (currentPage, pageCount) {
            return { text: currentPage.toString() + ' of ' + pageCount.toString(), style: 'footerStyle' };
        },
        exporterPdfCustomFormatter: function (docDefinition) {
            docDefinition.styles.headerStyle = { fontSize: 22, bold: true };
            docDefinition.styles.footerStyle = { fontSize: 10, bold: true };
            return docDefinition;
        },
        exporterPdfOrientation: 'portrait',
        exporterPdfPageSize: 'LETTER',
        exporterPdfMaxGridWidth: 500,
        exporterCsvLinkElement: angular.element(document.querySelectorAll(".custom-csv-link-location")),
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }
    };

    // Loads all active Inmates
    this.loadActiveInmates = function( ){
        InmatesService.getActiveInmates( loadInmates );
    };
    var loadInmates = function (data){
        $scope.gridOptions.data = data;
    };
    $scope.export = function(){
        if ($scope.export_format == 'csv') {
            var myElement = angular.element(document.querySelectorAll(".custom-csv-link-location"));
            $scope.gridApi.exporter.csvExport( $scope.export_row_type, $scope.export_column_type, myElement );
        } else if ($scope.export_format == 'pdf') {
            $scope.gridApi.exporter.pdfExport( $scope.export_row_type, $scope.export_column_type );
        };
    };

});