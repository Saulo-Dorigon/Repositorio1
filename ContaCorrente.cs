﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculoBancario
{
    class ContaCorrente : Conta
    {
        float tarifaSaque = 0.37f / 100;
        float tarifaTransferencia = 0.10f / 100;
        float valorDepositado;
        int valorSaque;
        float valorTransferencia;

        public ContaCorrente(string nomeCorrentista, int numeroIdentificacao, float saldoAtual) : base(nomeCorrentista, numeroIdentificacao, saldoAtual)
        {

        }

        public void VerificarSaldo()
        {
            Console.WriteLine($"\n O saldo de {NomeCorrentista} é de {SaldoAtual} reais.\n");

        }

        public float DepositarDinheiro(float valor)
        {
            valorDepositado = valor;
            SaldoAtual = SaldoAtual + valorDepositado;
            Console.WriteLine($" {NomeCorrentista} depositou: {valorDepositado} reais. \n Seu saldo é de {SaldoAtual} reais.\n");
            return SaldoAtual;
        }

        public int SacarDinheiro(int valor)
        {
            valorSaque = valor;
            Console.WriteLine($" {NomeCorrentista}  está tentando sacar R$ {valorSaque} de R$ {SaldoAtual} diponiveis na conta" +
                $" com uma tarifa de R$ {valorSaque * tarifaSaque}\n");

            if (SaldoAtual > 0 && (valorSaque < SaldoAtual) && (SaldoAtual - valorSaque >= valorSaque * tarifaSaque))
            {

                SaldoAtual = SaldoAtual - valorSaque - (valorSaque * tarifaSaque);

                return valorSaque;
            }
            else
            {
                Console.WriteLine(" Saldo insuficiente.\n Impossível de concluir a operação\n");

                return 0;
            }
        }

        public float TransferirDinheiro(float valor, string nomeAlvoTransferencia)
        {
            valorTransferencia = valor;
            Console.WriteLine($" {NomeCorrentista}  está tentando transferir R$ {valorTransferencia} de R$ {SaldoAtual} diponiveis na conta, para {nomeAlvoTransferencia}." +
                $" Essa operação tem uma tarifa de R$ {valorTransferencia * tarifaTransferencia}\n");

            if (SaldoAtual > 0 && (valorTransferencia < SaldoAtual) && (SaldoAtual - valorTransferencia >= valorTransferencia * tarifaTransferencia))
            {

                SaldoAtual = SaldoAtual - valorTransferencia - (valorTransferencia * tarifaTransferencia);

                return valorTransferencia;
            }
            else
            {
                Console.WriteLine(" Saldo insuficiente.\n Impossível de concluir a operação\n");

                return 0;
            }
        }

        public float DinheiroTransferido(float valorTrans, string nomeQuemTransferiu)
        {

            SaldoAtual = SaldoAtual + valorTrans;
            Console.WriteLine($" {nomeQuemTransferiu} transferiu R${valorTrans} para a sua conta.\n" +
                $" Seu saldo atual é de: R${SaldoAtual}\n");
            return valorTrans;
        }


    }
}