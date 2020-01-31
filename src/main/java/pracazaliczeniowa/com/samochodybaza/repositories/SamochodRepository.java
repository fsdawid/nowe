package pracazaliczeniowa.com.samochodybaza.repositories;

import org.springframework.data.repository.CrudRepository;
import pracazaliczeniowa.com.samochodybaza.model.Samochod;

public interface SamochodRepository extends CrudRepository<Samochod, Long> {
}
