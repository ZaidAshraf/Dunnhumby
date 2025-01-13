import { useState, useEffect } from "react";
import { getProducts } from "./api/simpleproductapi";
import { Datatable } from "./components/datatable"
import { Graph } from "./components/graph"
import { ProductModel } from "./models/productmodel";

const App = () => {
  const [products, setProducts] = useState<ProductModel[]>([]);

  useEffect(() => {
    const getProductData = async () => {
      const data = await getProducts();
      setProducts(data);
    };
    getProductData();
  }, []);

  console.log(products);

  return (
    <div style={{ margin: "20px", padding: "20px" }}>
      <div style={{ border: "1px solid black" }}>
        <Datatable products={products} />
      </div>
      <br />
      <div style={{ border: "1px solid black" }}>
        <Graph products={products} />
      </div>
    </div>
  )
}

export default App
