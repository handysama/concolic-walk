package gov.nasa.jpf.symbc.string.graph;

import gov.nasa.jpf.symbc.string.SymbolicLastIndexOfInteger;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class EdgeLastIndexOf implements Edge {

	Vertex source, dest;
	SymbolicLastIndexOfInteger sioi;
	String name;
	
	public EdgeLastIndexOf (String name, Vertex source, Vertex dest, SymbolicLastIndexOfInteger sioi) {
		this.name = name;
		this.source = source;
		this.dest = dest;
		this.sioi = sioi;
	}
	
	@Override
	public boolean allVertecisAreConstant() {
		return source.isConstant() && dest.isConstant();
	}

	@Override
	public Vertex getDest() {
		return dest;
	}

	@Override
	public String getName() {
		return name;
	}

	@Override
	public Vertex getSource() {
		return source;
	}

	@Override
	public List<Vertex> getSources() {
		List<Vertex> result = new ArrayList<Vertex>();
		result.add (source);
		return result;
	}

	@Override
	public boolean isDirected() {
		return true;
	}

	@Override
	public boolean isHyper() {
		return false;
	}

	@Override
	public void setDest(Vertex v) {
		this.dest = v;
	}

	@Override
	public void setSource(Vertex v) {
		this.source= v;
	}
	
	public SymbolicLastIndexOfInteger getIndex () {
		return sioi;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((dest == null) ? 0 : dest.hashCode());
		result = prime * result + ((source == null) ? 0 : source.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		EdgeLastIndexOf other = (EdgeLastIndexOf) obj;
		if (dest == null) {
			if (other.dest != null)
				return false;
		} else if (!dest.equals(other.dest))
			return false;
		if (source == null) {
			if (other.source != null)
				return false;
		} else if (!source.equals(other.source))
			return false;
		return true;
	}

	@Override
	public Edge cloneAndSwapVertices(Map<Vertex, Vertex> oldToNew) {
		return new EdgeLastIndexOf(name, oldToNew.get(source),
				oldToNew.get(dest), sioi);
	}

}
