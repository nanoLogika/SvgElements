namespace SvgElements {
    public interface IGroupElementBase<ChildrenT> {
        List<SvgElementBase<ChildrenT>> Children { get; }
    }
}