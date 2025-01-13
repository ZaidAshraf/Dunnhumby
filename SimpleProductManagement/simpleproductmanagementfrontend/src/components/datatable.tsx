import { ProductModel } from "../models/productmodel";
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';

type DatatableProps = {
    products: ProductModel[];
}

const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'category', headerName: 'Category', width: 130 },
    { field: 'name', headerName: 'Name', width: 130 },
    { field: 'productCode', headerName: 'Product Code', width: 130 },
    { field: 'price', headerName: 'Price', width: 130 },
    { field: 'stockQuantity', headerName: 'Stock Quantity', width: 130 },
    { field: 'dateAdded', headerName: 'Date Added', width: 400 },
];

const productDataToRows = (products: ProductModel[]) => {
    const rows = products.map((product) => {
        return {
            id: product.id,
            name: product.name,
            category: product.category,
            productCode: product.productCode,
            price: product.price,
            stockQuantity: product.stockQuantity,
            dateAdded: product.dateAdded.toString(),
        }
    })
    return rows;
}

const paginationModel = { page: 0, pageSize: 5 };

export const Datatable = ({ products }: DatatableProps) => {

    return (
        <Paper sx={{ height: 400, width: '100%' }}>
            <DataGrid
                rows={productDataToRows(products)}
                columns={columns}
                initialState={{ pagination: { paginationModel } }}
                pageSizeOptions={[5, 10]}
            />
        </Paper>
    );
}
