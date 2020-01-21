package pracazaliczeniowa.com.samochodybaza.model;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;
@Entity
public class Model {
    @Id
    @GeneratedValue
    private Long Id;
    private String Nazwa_modelu;
    @ManyToOne
    private Marka Marka;

    public Model() {
    }

    public Model(Long id, pracazaliczeniowa.com.samochodybaza.model.Marka marka) {
        Id = id;
        Marka = marka;
    }

    public Model(String nazwa_modelu) {
        Nazwa_modelu = nazwa_modelu;

    }

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }




    public String getNazwa_modelu() {
        return Nazwa_modelu;
    }

    public void setNazwa_modelu(String nazwa_modelu) {
        Nazwa_modelu = nazwa_modelu;
    }

    public pracazaliczeniowa.com.samochodybaza.model.Marka getMarka() {
        return Marka;
    }

    public void setMarka(pracazaliczeniowa.com.samochodybaza.model.Marka marka) {
        Marka = marka;
    }

    @Override
    public String toString() {
        return "Model{" +
                "Id=" + Id +

                ", Nazwa_modelu='" + Nazwa_modelu + '\'' +
                ", Marka=" + Marka +
                '}';
    }
}


