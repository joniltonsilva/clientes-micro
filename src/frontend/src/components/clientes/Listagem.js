import React, { useState, useEffect } from 'react'
import Api from "../../services/clientes-api"

export default function Listagem() {

    const [clientes, setClientes] = useState([]);
    const [clienteAtual, setClienteAtual] = useState({});

    useEffect(() => {
        async function recuperarListagem(){
            const response = await Api.get();
            console.log(response)
            if(response.status == 200){
                setClientes(response.data);
            }
        }

        recuperarListagem();
    });

    const atualizarCliente = (id) => {

    }

    const deletarCliente = (id) => {

    }

  return (
    <div className="card mt-4">
        <div className="card-header">
            <h4 className="card-title"> Lista de Clientes </h4>
            <button type="button" className="btn btn-primary btn-sm pull-right" data-toggle="modal" data-target="#addModal"> Cadastrar </button>
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
                                <button className="btn btn-info btn-sm mr-2" onClick={() => atualizarCliente(cliente.Id)} data-toggle="modal" data-target="#editModal"> Alterar </button>
                                <button className="btn btn-danger btn-sm" onClick={() => deletarCliente(cliente.Id)}> Deletar </button>
                            </td>
                        </tr>
                    ))}
                    </tbody>
                </table>
            </div>
        </div>
        {/* <Create updateState = {this.handleUpdateState} />
        <Edit updateState = {this.handleUpdateState} user = {this.state.editUser} /> */}
    </div>
  )
}
