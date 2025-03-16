package com.Java_Odontoprev_v2.repository;

import com.Java_Odontoprev_v2.model.Cliente;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ClienteRepository extends JpaRepository<Cliente, String> {
}
