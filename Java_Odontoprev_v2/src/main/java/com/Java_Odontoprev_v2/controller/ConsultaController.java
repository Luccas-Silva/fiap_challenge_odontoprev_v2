package com.Java_Odontoprev_v2.controller;

import com.Java_Odontoprev_v2.model.Cliente;
import com.Java_Odontoprev_v2.model.Consulta;
import com.Java_Odontoprev_v2.repository.ClienteRepository;
import com.Java_Odontoprev_v2.repository.ConsultaRepository;
import com.Java_Odontoprev_v2.repository.DentistaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@Controller
@RequestMapping("/consulta")
@RequiredArgsConstructor
@Validated
public class ConsultaController {

    @Autowired
    private ConsultaRepository consultaRepository;
    @Autowired
    private ClienteRepository clienteRepository;
    @Autowired
    private DentistaRepository dentistaRepository;

    @GetMapping("/lista")
    public String listaConsulta(Model model) {
        List<Consulta> consultas = consultaRepository.findAll();
        model.addAttribute("consultas", consultas);
        return "consulta/lista";
    }

    @GetMapping("/novo")
    public String novoConsulta(Model model) {
        model.addAttribute("consulta", new Consulta());
        model.addAttribute("clientes", clienteRepository.findAll());
        model.addAttribute("dentistas", dentistaRepository.findAll());
        return "consulta/novo";
    }

    @PostMapping("/salvar")
    public String salvarConsulta(@ModelAttribute Consulta consulta, BindingResult result, Model model) {
        if (result.hasErrors()) {
            model.addAttribute("consulta", consulta);
            model.addAttribute("clientes", clienteRepository.findAll());
            model.addAttribute("dentistas", dentistaRepository.findAll());
            return "consulta/formulario";
        }

        if (consulta.getCliente() != null && consulta.getCliente().getIdCliente() != null) {
            clienteRepository.findById(consulta.getCliente().getIdCliente())
                    .ifPresent(consulta::setCliente);
        } else {
            consulta.setCliente(null);
        }

        if (consulta.getDentista() != null && consulta.getDentista().getIdDentista() != null) {
            dentistaRepository.findById(consulta.getDentista().getIdDentista())
                    .ifPresent(consulta::setDentista);
        } else {
            consulta.setDentista(null);
        }

        consultaRepository.save(consulta);
        return "redirect:/consulta/lista";
    }

    @GetMapping("/editar/{id}")
    public String editarConsulta(@PathVariable String id, Model model) {
        Optional<Consulta> consulta = consultaRepository.findById(id);
        if (consulta.isPresent()){
            model.addAttribute("consulta", consulta.get());
            return "consulta/formulario";
        }
        return "consulta/novo";
    }

    @GetMapping("/deletar/{id}")
    public String deletarConsulta(@PathVariable String id) {
        consultaRepository.deleteById(id);
        return "redirect:/consulta/lista";
    }

}
