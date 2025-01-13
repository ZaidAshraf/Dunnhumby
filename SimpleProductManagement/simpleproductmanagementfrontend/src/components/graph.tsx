import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import { ProductModel } from '../models/productmodel';

type GraphProps = {
    products: ProductModel[];
}

export const Graph = ({ products }: GraphProps) => {

    const totalStockByCategory = products.reduce<Record<string, number>>((acc, product) => {
        acc[product.category] = (acc[product.category] || 0) + product.stockQuantity;
        return acc;
    }, {} as Record<string, number>);

    const chartData = Object.entries(totalStockByCategory).map(([category, totalStock]) => ({
        category,
        totalStock,
    }));

    console.log(totalStockByCategory);
    console.log(chartData);

    return (
        <ResponsiveContainer width="100%" height={400}>
            <BarChart data={chartData}>
                <CartesianGrid strokeDasharray="3 3" />
                <XAxis dataKey="category" />
                <YAxis />
                <Tooltip />
                <Bar dataKey="totalStock" fill="#8884d8" />
            </BarChart>
        </ResponsiveContainer>
    );
}