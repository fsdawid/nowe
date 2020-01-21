package pracazaliczeniowa.com.samochodybaza.model;

import javax.persistence.*;
import java.util.Set;
@Entity
public class Marka {
    @Id
    @GeneratedValue
    private Long Id;
    private String Nazwa_marki;

    public Marka() {
    }

    public Marka(Long id) {
        Id = id;
    }

    public Marka(String nazwa_marki) {
        Nazwa_marki = nazwa_marki;
    }

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }

    public String getNazwa_marki() {
        return Nazwa_marki;
    }

    public void setNazwa_marki(String nazwa_marki) {
        Nazwa_marki = nazwa_marki;
    }

    @Override
    public String toString() {
        return "Marka{" +
                "Id=" + Id +
                ", Nazwa_marki='" + Nazwa_marki + '\'' +
                '}';
    }
}



