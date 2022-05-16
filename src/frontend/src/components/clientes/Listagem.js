import React, { useState, useEffect } from 'react'
import Api from "../../services/clientes-api"
import Atualizar from './Atualizar';
import Cadastrar from './Cadastrar';

export default function Listagem() {

    const [carregando, setCarregando] = useState(true);
    const [clientes, setClientes] = useState([]);
    const [clienteAtual, setClienteAtual] = useState({});

    useEffect(() => {
        recuperarListagem();
    },[]);

    const recuperarListagem = async () => {
        setCarregando(true);
        const response = await Api.get();
        if(response.status == 200){
            setClientes(response.data);
        }
        setCarregando(false);
    }

    const deletarCliente = (id) => {

    }

  return (
    <div className="card mt-4">
        <div className="card-header">
            <h4 className="card-title"> Lista de Clientes </h4>
            <button type="button" className="btn btn-primary btn-sm pull-right" data-toggle="modal" data-target="#cadastrarModal"> Cadastrar </button>
        </div>
        <div className="card-body">
            <div className="col-md-12">
                <table className="table table-bordered">
                    <thead>
                        <tr>
                            <th> Id </th>
                            <th> Nome </th>
                            <th> Porte </th>
                            <th>  </th>
                        </tr>
                    </thead>
                    <tbody>
                    {clientes && clientes.map((cliente, i) => (
                        <tr key={i}>
                            <td> {cliente.Id} </td>
                            <td> {cliente.Nome} </td>
                            <td> {cliente.Porte} </td>
                            <td>
                                <button className="btn btn-info btn-sm mr-2" onClick={() => setClienteAtual(cliente)} data-toggle="modal" data-target="#atualizarModal"> Alterar </button>
                                <button className="btn btn-danger btn-sm" onClick={() => deletarCliente(cliente.Id)}> Deletar </button>
                            </td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        </div>
        <Cadastrar />
        <Atualizar cliente={clienteAtual} />
    </div>
  )
}
