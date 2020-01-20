package pracazaliczeniowa.com.samochodybaza.model;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import java.util.Set;
@Entity
public class Marka {
    @Id
    private Long Id;
    private String Nazwa_marki;

    public Marka() {
    }

    public Marka(Long id, String nazwa_modelu) {
        Id = id;
        Nazwa_marki = nazwa_modelu;
    }

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }

    public String getNazwa_modelu() {
        return Nazwa_marki;
    }

    public void setNazwa_modelu(String nazwa_modelu) {
        Nazwa_marki = nazwa_modelu;
    }

    @Override
    public String toString() {
        return "Marka{" +
                "Id=" + Id +
                ", Nazwa_modelu='" + Nazwa_marki + '\'' +
                '}';
    }
}



